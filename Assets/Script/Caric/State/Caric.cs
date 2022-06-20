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
    public float bulletSpeed = 4f;

    public float maxAttackTime = 0;
    public float curAttackTime = 0;
    public Vector2 Target_Pos = Vector2.zero;

    public GameObject player;
    public ENEMYTYPE enemyType;
    public MONSTERTYPE monsterType;

    protected State state;
    protected AiState aiState;
    public State AttackState;

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

        SetEnemyType();

        player = Resources.Load<GameObject>("Prefabs/Player/B_Player");
    }

    void Start()
    {

    }
    void Update()
    {

    }
    public void Die()
    {
        if (gameObject.tag == "Enemy")
        {
            J.IngameManager.playerKillCount += 1;
            aiState.ChangeState(gameObject.AddComponent<EnemyDie>());
        }
    }
    public void Hit()
    {
        if (gameObject.tag == "Enemy")
        {
            aiState.ChangeState(gameObject.AddComponent<EnemyHit>());
        }
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

    void SetEnemyType()
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
        }
    }

    public abstract State GetState();

    // 적 공격 마지막 이벤트
    public void ChangeIdle()
    {
        //땅의 원소 공격 마지막
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }

    public void EnemyChanageDie()
    {
        Destroy(gameObject);
    }

    public void PlayerKillPlus()
    {
        J.IngameManager.playerKillCount += 1;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }

}
