using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Caric : MonoBehaviour
{
    public CARICSTATE CS = CARICSTATE.IDLE;
    public int Hp = 0;
    public int Dmg = 0;
    public float MoveSpeed = 0;
    public float DelayTime = 0;
    public float Direction = 0;   

    public float maxAttackTime = 0;
    public float curAttackTime = 0;
    public Vector2 Target_Pos = Vector2.zero;

    protected State state;
    protected AiState aiState;
    public State AttackState;

    public Animator anim = null;
    public SpriteRenderer spriteRenderer = null;
    public Collider2D collider2D = null;
    void Awake()
    {
        state = GetComponent<State>();
        aiState = GetComponent<AiState>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Die()
    {
        anim.SetBool("isWalk", false);
        anim.SetBool("isDie", true);
        SetDieDelay(1f);
    }
    public void Hit()
    {   
        anim.SetTrigger("isHit");
        SetDelay(0.3f);
        Debug.Log("Hp : " + Hp);
    }
    public void SetDelay(float time)
    {
        CS = CARICSTATE.DELAY;
        DelayTime = J.WorldTime + time;
    }
    public void SetDieDelay(float time)
    {
        CS = CARICSTATE.DIE;
        DelayTime = J.WorldTime + time;
    }

    public abstract State GetState(); 

    // 적 공격 마지막 이벤트
    public void ChangeAttack()
    {
        //땅의 원소 공격 마지막
        aiState.ChangeState(gameObject.AddComponent<EnemyIdle>());
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }

}
