using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : State
{
    public override void Enter()
    {
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();
        caric.anim.Play("Walk");
    }

    public override void Tick()
    {
        float Distance = caric.Target_Pos.x - transform.position.x;

                //caric.GetComponent<Animator>().SetBool("isAttack", false);

                if (Mathf.Abs(Distance) <= 0.02f * caric.MoveSpeed)
                {
                    //caric.GetComponent<Animator>().SetBool("isWalk", false);
                    caric.anim.Play("Idle");
                }
                else
                {
                    transform.Translate(transform.right * caric.Direction * caric.MoveSpeed * Time.deltaTime);
                }

                if (caric.maxAttackTime <= caric.curAttackTime)
                {
                    aiState.ChangeState(caric.GetState());
                    caric.curAttackTime = 0;
                }
                else
                {
                    caric.curAttackTime += Time.deltaTime;
                }
    }
    public override void Exit()
    {
    }
}
