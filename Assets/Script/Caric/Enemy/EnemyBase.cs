using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : Caric
{
    
    public Vector2 Target_Pos = Vector2.zero;

    SpriteRenderer spriteRenderer = null;

    int Direction = 0;
    // Start is called before the first frame update
    void Init()
    {
        Hp = 10;
        Dmg = 10;
        MoveSpeed = 1;
    }

    void Start()
    {
        Init();

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyLogic();
    }

    public void EnemyLogic()
    {
        switch(CS)
        {
            case CARICSTATE.IDLE:

                CS = CARICSTATE.SCAN;
                // RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 2f);
                // Debug.DrawRay(transform.position, transform.right * 2, Color.red, 0.3f);

                break;
            case CARICSTATE.SCAN:

                int r = Random.Range(0, 2);

                if(r == 0)
                {
                    
                    Target_Pos = new Vector2(Random.Range(-8, 8), transform.position.y);
                    
                    spriteRenderer.flipX = (Target_Pos.x - transform.position.x < 0) ? true : false;
                    Direction = (Target_Pos.x - transform.position.x < 0) ? -1 : 1;

                    anim.SetBool("Walk", true);
                    
                    CS = CARICSTATE.MOVE;

                }
                else // WaitTime
                {
                    SetDelay(Random.Range(1f, 3f));
                }

                break;
            case CARICSTATE.MOVE:

                float Distance = Target_Pos.x - transform.position.x;

                if(Mathf.Abs(Distance) <= 0.02f * MoveSpeed)
                {
                    anim.SetBool("Walk", false);
                    SetDelay(3f);
                }
                else
                {
                    transform.Translate(transform.right * Direction * MoveSpeed * Time.deltaTime);
                }

                break;
            case CARICSTATE.ATTACK:
                break;
            case CARICSTATE.HIT:
                break;
            case CARICSTATE.DIE:

                if(DelayTime < J.WorldTime)
                {
                    Destroy(gameObject);
                }

                break;
            case CARICSTATE.DELAY:

                if(DelayTime < J.WorldTime)
                {
                    anim.SetBool("Walk", false);
                    CS = CARICSTATE.IDLE;
                }

                break;
        }
    }


}
