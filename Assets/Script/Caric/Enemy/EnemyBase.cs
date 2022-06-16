using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : Caric
{
    public ENEMYPROPERTY enemyProperty;

    public Vector2 Target_Pos = Vector2.zero;

    SpriteRenderer spriteRenderer = null;

    int Direction = 0;

    public float curAttackTime = 0;
    public float maxAttackTime = 0;

    private void OnEnable()
    {
        maxAttackTime = Random.Range(6f, 13f);
    }
    // Start is called before the first frame update
    void Init()
    {
        Hp = 10;
        Dmg = 10;
        MoveSpeed = 1;
    }

    protected void Start()
    {
        Init();

        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    protected virtual void Update()
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


                if (r == 0)
                {
                    
                    Target_Pos = new Vector2(Random.Range(-8, 8), transform.position.y);
                    
                    spriteRenderer.flipX = (Target_Pos.x - transform.position.x < 0) ? true : false;
                    Direction = (Target_Pos.x - transform.position.x < 0) ? -1 : 1;

                    


                    CS = CARICSTATE.MOVE;

                }
                else // WaitTime
                {
                    SetDelay(Random.Range(1f, 3f));
                }

                break;
            case CARICSTATE.MOVE:

                float Distance = Target_Pos.x - transform.position.x;

                anim.SetBool("isAttack", false);

                if (Mathf.Abs(Distance) <= 0.02f * MoveSpeed)
                {
                    anim.SetBool("isWalk", false);
                    SetDelay(3f);
                }
                else
                {
                    transform.Translate(transform.right * Direction * MoveSpeed * Time.deltaTime);
                }

                if (maxAttackTime <= curAttackTime)
                {
                    CS = CARICSTATE.ATTACK;
                    curAttackTime = 0;
                }
                else
                {
                    curAttackTime += Time.deltaTime;
                }

                break;
            case CARICSTATE.ATTACK:
                anim.SetBool("isAttack", true);
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
                    anim.SetBool("isWalk", false);
                    CS = CARICSTATE.IDLE;
                }

                break;
        }
    }
    
    public void AttackEnd()
    {
        anim.SetBool("isAttack", false);
        CS = CARICSTATE.IDLE;
    }

}
