using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player_Main : Caric
{

    void Init()
    {
        Hp = 100;
        Dmg = 10;
        MoveSpeed = 6;
    }
    // Start is called before the first frame update
    void Start()
    {
        Init();

    }

    // Update is called once per frame
    void Update()
    {
        if(J.IngameManager.isGameStop)
            return;

        KeyInput();

        switch(CS)
        {
            case CARICSTATE.IDLE:
                
                anim.SetBool("isWalk", false);
                anim.SetBool("isJump", false);
                    
                break;
            case CARICSTATE.MOVE:

                Move();

                break;
            case CARICSTATE.JUMP:
                
                if(rigidbody2D.velocity.y < 0)
                {
                    anim.SetBool("isWalk", false);
                    CS = CARICSTATE.FALL;
                }
                
                break;
            case CARICSTATE.FALL:
                
                if(IsGround && rigidbody2D.velocity.y == 0)
                {
                    anim.SetBool("isWalk", false);
                    anim.SetBool("isJump", false);
                    CS = CARICSTATE.IDLE;
                }
                
                break;
            case CARICSTATE.DIE:
                
                
                break;
        }

        Debug.Log("Now State !! : " + CS.ToString());
        
    }

    public void KeyInput()
    {
        //PS = PLAYERSTATE.IDLE;
        
        x = Input.GetAxis("Horizontal");

        if(x != 0 && CS == CARICSTATE.IDLE)
        {
            anim.SetBool("isWalk", true);
            CS = CARICSTATE.MOVE;
        }
        if(Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            rigidbody2D.AddForce(Vector2.up * JumpForce);
            
            anim.SetBool("isWalk", false);
            anim.SetBool("isJump", true);
            
            IsGround = false;
            CS = CARICSTATE.JUMP;
        }

    }

    public void Move()
    {
        
        if(x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            CS = CARICSTATE.IDLE;
        }

        this.transform.Translate(new Vector2(MoveSpeed * x * Time.deltaTime, 0));
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Ground")
        {
            IsGround = true;
        }
    }
    public override State GetState()
    {
        return AttackState;
    }
}

