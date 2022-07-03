using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Caric : MonoBehaviour
{
    public Caric Owner = null;
    public CARICSTATE CS = CARICSTATE.IDLE;
    public int Hp = 0;
    public int Dmg = 0;
    public float MoveSpeed = 0;
    public float DelayTime = 0;
    public float Direction = 0;
    public float bulletSpeed = 4f;
    public float x = 0;
    public float JumpForce;
    public bool IsGround = false;
    public bool isMoleinvcible = false;
    public Player_Main playerMain = null;

    public bool isDash = false;
    public float defaultSpeed = 0;
    public float dashSpeed = 0;
    public float dashTime = 0;
    public float defaultTime = 7f;

    public float maxAttackTime = 0;
    public float curAttackTime = 0;
    public Vector2 Target_Pos = Vector2.zero;
    public ENEMYTYPE enemyType;
    public MONSTERTYPE monsterType;

    protected State state;
    protected AiState aiState;
    public State AttackState;
    public State playerJumpState;

    public Animator anim = null;
    public SpriteRenderer spriteRenderer = null;
    public Collider2D collider2D = null;
    public Rigidbody2D rigidbody2D = null;

    
    void Awake()
    {
        state = GetComponent<State>();
        aiState = GetComponent<AiState>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        playerMain = FindObjectOfType(typeof(Player_Main)) as Player_Main;

        InitEnemyType();

    }

    void Start()
    {

    }
    void Update()
    {

    }
    public virtual void Die()
    {

    }
    public virtual void Hit()
    {

    }
    void InitEnemyType()
    {
        switch (enemyType)
        {
            case ENEMYTYPE.GROUNDELEMENT:
                Hp = 20;
                Dmg = 5;
                MoveSpeed = 1.5f;
                break;
            case ENEMYTYPE.TROLL:
                Hp = 40;
                Dmg = 20;
                MoveSpeed = 1f;
                break;
            case ENEMYTYPE.MOLE:
                Hp = 30;
                Dmg = 10;
                MoveSpeed = 2f;
                break;
            case ENEMYTYPE.GOLEM:
                Hp = 200;
                Dmg = 10;
                MoveSpeed = 0.7f;
                break;
            case ENEMYTYPE.WATERELEMENT:
                Hp = 20;
                Dmg = 5;
                MoveSpeed = 1.5f;
                break;
            case ENEMYTYPE.FROG:
                Hp = 20; 
                Dmg = 5;
                MoveSpeed = 1.5f;
                break;
            case ENEMYTYPE.SLIME:
                Hp = 20;
                Dmg = 5;
                MoveSpeed = 1.5f;
                break;
        }
        if (gameObject.tag == "Player")
        {
            Hp = 100;
            Dmg = 10;
            MoveSpeed = 6;
        }
    }
    public abstract State GetState();


    //적 이벤트 함수

    // 적 공격 마지막 이벤트
    public void ChangeIdle()
    {
        //땅의 원소 공격 마지막
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }

    public void EnemyChanageDie()
    {
        J.IngameManager.playerKillCount += 1;
        J.SpawnManager.GroundEnemies.Remove(gameObject);
        Destroy(gameObject);
    }

    public void PlayerHit()
    {
        Debug.Log("다시 원상복귀");
        CS = CARICSTATE.IDLE;
    }

    public void ObjDestroy()
    {
        Destroy(gameObject);
    }

    public void MoleAttack2()
    {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x,0.9f);
        anim.Play("Attack2");
        isMoleinvcible = true;   
    }

    public void MoleAttackGra()
    {
        rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        Invoke("MoleReState", Random.Range(5f,10f));
    }

    void MoleReState()
    {
        isMoleinvcible = false;
        rigidbody2D.constraints = ~RigidbodyConstraints2D.FreezePositionX & ~RigidbodyConstraints2D.FreezePositionY;
        gameObject.transform.position = new Vector2(gameObject.transform.position.x,2f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }
 

}
