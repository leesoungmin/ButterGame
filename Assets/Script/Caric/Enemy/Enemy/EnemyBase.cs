using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : Caric
{
    public bool IsDestroy => Hp <= 0;
    private void OnEnable()
    {
        maxAttackTime = Random.Range(6f, 13f);
    }

    // Start is called before the first frame update
    void Init()
    {
        aiState = GetComponent<AiState>();

        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }

    protected void Start()
    {
        Init();
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    public override void Hit()
    {
        if (isMoleinvcible)
        {
            return;
        }

        base.Hit();

        switch (enemyType)
        {
            case ENEMYTYPE.GOLEM:
                Instantiate(hitEffectPrefab, gameObject.transform.position, Quaternion.identity);
                aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
                break;
            case ENEMYTYPE.MERMAID:
                Instantiate(hitEffectPrefab, gameObject.transform.position, Quaternion.identity);
                aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
                break;
            case ENEMYTYPE.CERBERUS:
                aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
                break;
            default:
                aiState.ChangeState(gameObject.AddComponent<EnemyHit>());
                break;
        }
    }



    public override void Die()
    {
        if (GetComponent<State>().GetType().Name == "EnemyDie")
            return;
        Debug.Log("죽어버렸어 헤이헤이");
        
        J.SpawnManager.enemyCount--;

        base.Die();
        aiState.ChangeState(gameObject.AddComponent<EnemyDie>());
    }

}
