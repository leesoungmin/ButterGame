using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDelay : State
{

    public override void Enter()
    {
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();


    }

    public override void Tick()
    {
        if(caric.DelayTime < J.WorldTime)
        {
            aiState.ChangeState(gameObject.AddComponent<EnemyMove>());
        }
    }

    public override void Exit()
    {
    }
}
