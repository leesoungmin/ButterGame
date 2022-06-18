using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrollAttack : State
{
    public override void Enter()
    {
    }

    public override void Tick()
    {
    }

    public override void Exit()
    {
    }

    public override void SetAttackState(ENEMYTYPE enemyType)
    {
        switch(enemyType)
        {
            case ENEMYTYPE.GROUNDELEMENTATTCK:
            AttackState = gameObject.AddComponent<GroundElementAttack>();
            break;
            case ENEMYTYPE.GROUNDTROLLATTACK:
            break;
        }
    }
}
