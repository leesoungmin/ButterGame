using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundElementAttack : State
{
    EnemyBase enemyBase;
    public override void Enter()
    {
        enemyBase = GetComponent<EnemyBase>();

    }

    public override void Tick()
    {
        
    }

    public override void Exit()
    {
        Fire();
        aiState.ChangeState(gameObject.AddComponent<EnemyIdle>());
        caric.anim.Play("Attack");
    }

    void Fire()
    {
        Instantiate(enemyBase.obj_GroundElementBulet, transform.position, Quaternion.identity);
    }

    public override void SetAttackState(ENEMYTYPE enemyType)
    {
        switch(enemyType)
        {
            case ENEMYTYPE.GROUNDELEMENTATTCK:
            AttackState = gameObject.AddComponent<GroundElementAttack>();
            break;
            case ENEMYTYPE.GROUNDTROLLATTACK:
            AttackState = gameObject.AddComponent<GroundTrollAttack>();
            break;
        }
    }
}
