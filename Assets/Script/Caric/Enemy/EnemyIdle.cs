using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : State
{
    public override void Enter()
    {
        aiState = GetComponent<AiState>();
        aiState.ChangeState(gameObject.AddComponent<EnemyMove>());
        Debug.Log("평범한 상태");
    }

    public override void Tick()
    {
        
    }

    public override void Exit()
    {
    }

}
