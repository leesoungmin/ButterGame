using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player_Main : Caric
{
    SpriteRenderer spriteRenderer = null;
    Rigidbody2D rigid = null;
    float x;
    public bool IsGround = false;

    public float JumpForce;

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

        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        KeyInput();

        switch(CS)
        {
            case CARICSTATE.IDLE:
                
                anim.SetBool("Walk", false);
                anim.SetBool("Jump", false);
                anim.SetBool("Fall", false);
                    
                break;
            case CARICSTATE.MOVE:

                Move();

                break;
            case CARICSTATE.JUMP:
                
                if(rigid.velocity.y < 0)
                {
                    anim.SetBool("Walk", false);
                    anim.SetBool("Fall", true);
                    CS = CARICSTATE.FALL;
                }
                
                break;
            case CARICSTATE.FALL:
                
                if(IsGround && rigid.velocity.y == 0)
                {
                    anim.SetBool("Walk", false);
                    anim.SetBool("Jump", false);
                    anim.SetBool("Fall", false);
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
            anim.SetBool("Walk", true);
            CS = CARICSTATE.MOVE;
        }
        if(Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            rigid.AddForce(Vector2.up * JumpForce);
            
            anim.SetBool("Walk", false);
            anim.SetBool("Jump", true);
            
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
}

