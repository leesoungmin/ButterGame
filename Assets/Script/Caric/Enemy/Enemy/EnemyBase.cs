using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : Caric
{
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
        aiState = GetComponent<AiState>();

        aiState.ChangeState(gameObject.AddComponent<EnemyIdle>());

    }

    protected void Start()
    {
        Init();

        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        

    }

}
