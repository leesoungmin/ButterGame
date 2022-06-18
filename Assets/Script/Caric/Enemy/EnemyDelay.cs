using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDelay : State
{

    public override void Enter()
    {

    }

    public override void Tick()
    {
        if(caric.DelayTime < J.WorldTime)
        {
            aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
        }
    }

    public override void Exit()
    {
    }
    public override void SetAttackState(ENEMYTYPE enemyType)
    {
    }
}
