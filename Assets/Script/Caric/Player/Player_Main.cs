using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoveRange
{
    public float xMin;
    public float xMax;
}

public partial class Player_Main : Caric
{
    ParticleSystem playerDashParticle = null;
    public MoveRange moveRange;
    public AudioClip clip;
    void Init()
    {
        Hp = 100;
        Dmg = 10;
        MoveSpeed = 6;
        maxDashCool = 7f;
        defaultSpeed = MoveSpeed;
        curDashCool = 0;
        isPlayerInvcible = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();

        playerDashParticle = GetComponentInChildren<ParticleSystem>();

    }



    // Update is called once per frame
    void Update()
    {
        if (J.IngameManager.isGameStop)
            return;

        KeyInput();
        //ScreeChik();

        switch (CS)
        {
            case CARICSTATE.IDLE:

                anim.SetBool("isWalk", false);
                anim.SetBool("isJump", false);

                break;
            case CARICSTATE.MOVE:

                Move();

                break;
            case CARICSTATE.JUMP:

                if (rigidbody2D.velocity.y < 0)
                {
                    anim.SetBool("isWalk", false);
                    CS = CARICSTATE.FALL;
                }

                break;
            case CARICSTATE.FALL:

                if (IsGround && rigidbody2D.velocity.y == 0)
                {
                    anim.SetBool("isWalk", false);
                    anim.SetBool("isJump", false);
                    CS = CARICSTATE.IDLE;
                }
                break;

            case CARICSTATE.HIT:



                break;

            case CARICSTATE.DIE:


                break;
        }

        if (curDashCool >= maxDashCool)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isDash = true;
                isPlayerInvcible = true;
                playerDashParticle.Play();
                curDashCool = 0;
            }
        }
        else
        {
            curDashCool += Time.deltaTime;
        }

        if (dashTime <= 0)
        {
            defaultSpeed = MoveSpeed;
            if (isDash)
            {
                dashTime = defaultTime;
            }
            if (!isDash)
            {
                playerDashParticle.Stop();
                isPlayerInvcible = false;
            }
        }
        else
        {
            dashTime -= Time.deltaTime;
            defaultSpeed = dashSpeed;
        }
        isDash = false;

        Debug.Log("Now State !! : " + CS.ToString());

    }

    public void KeyInput()
    {
        //PS = PLAYERSTATE.IDLE;

        x = Input.GetAxis("Horizontal");

        if (x != 0 && CS == CARICSTATE.IDLE)
        {
            anim.SetBool("isWalk", true);
            CS = CARICSTATE.MOVE;
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGround)
        {

            //SoundManager.instace.SFXPlay("Jump");

            rigidbody2D.AddForce(Vector2.up * JumpForce);

            anim.SetBool("isWalk", false);
            anim.SetBool("isJump", true);

            IsGround = false;

            CS = CARICSTATE.JUMP;
        }

    }

    public override void Die()
    {
        base.Die();
    }
    public override void Hit()
    {
        

        base.Hit();
        anim.SetTrigger("isHit");
        CS = CARICSTATE.HIT;
    }

    void Unbeatable()
    {
        isPlayerInvcible = true;
        if (isPlayerInvcible)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        }

        Invoke("UnbeatableFalse",3f);
    }

    void UnbeatableFalse()
    {
        isPlayerInvcible = false;
        if (!isPlayerInvcible)
        {
            spriteRenderer.color = new Color(1, 1, 1, 1); //?????? ?????? ??????

        }
    }
    public void Move()
    {

        if (x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            CS = CARICSTATE.IDLE;
        }

        //this.transform.Translate(new Vector2(MoveSpeed * x * Time.smoothDeltaTime, 0));

        var curPos = transform.position;
        curPos += new Vector3(x, 0, 0) * defaultSpeed * Time.deltaTime;
        curPos.x = Mathf.Clamp(curPos.x, moveRange.xMin, moveRange.xMax);
        transform.position = curPos;

        

    }

    void RigidMove()
    {
        // Vector2 pos = rigidbody2D.position;
        // pos.x = pos.x + MoveSpeed * x * Time.deltaTime;
        // rigidbody2D.MovePosition(pos);
    }


    void ScreeChik()
    {
        Vector3 worlPos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worlPos.x < -8.3f) worlPos.x = -8.3f;
        if (worlPos.x > 8f) worlPos.x = 8f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worlPos);
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Ground")
        {
            IsGround = true;
        }
        else if (other.gameObject.tag == "Enemy")
        {
            if (isPlayerInvcible)
                return;
            new JudgmentSign((other.gameObject.GetComponent<Caric>().Owner == null) ? other.gameObject.GetComponent<Caric>() : other.gameObject.GetComponent<Caric>().Owner, this);
            Unbeatable();

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Enemy")
        {
            if (isPlayerInvcible)
                return;
            
            new JudgmentSign((other.GetComponent<Caric>().Owner == null) ? other.GetComponent<Caric>() : other.GetComponent<Caric>().Owner, this);
            Unbeatable();
        }
    }
    public override State GetState()
    {
        return AttackState;
    }
}

