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
                    //움직임
                    // Vector2 position = caric.rigidbody2D.position;
                    // position.x =  position.x + caric.Direction * caric.MoveSpeed * Time.deltaTime; 
                    // caric.rigidbody2D.MovePosition(position);
                    // Debug.Log(position.x);

                    transform.Translate(transform.right * caric.Direction * caric.MoveSpeed * Time.deltaTime);
                }
                
                //공격
                if (caric.maxAttackTime <= caric.curAttackTime)
                {
                    aiState.ChangeState(caric.GetState());
                    caric.maxAttackTime = Random.Range(3f, 8f);
                    //보스는 따로
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
