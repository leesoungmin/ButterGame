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
        base.Hit();
        aiState.ChangeState(gameObject.AddComponent<EnemyHit>());
    }

    public override void Die()
    {
        base.Die();
        aiState.ChangeState(gameObject.AddComponent<EnemyDie>());
    }

}
