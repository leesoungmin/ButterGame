using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScan : State
{
    public override void Enter()
    {
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();
    }

    public override void Tick()
    {
        int r = Random.Range(0, 2);

                if (r == 0)
                {
                    
                    caric.Target_Pos = new Vector2(Random.Range(-8, 8), transform.position.y);
                    
                    caric.GetComponent<SpriteRenderer>().flipX = (caric.Target_Pos.x - transform.position.x < 0) ? true : false;
                    caric.Direction = (caric.Target_Pos.x - transform.position.x < 0) ? -1 : 1;

                    caric.GetComponent<Animator>().Play("Walk");

                    Debug.Log("스캔중");

                    aiState.ChangeState(gameObject.AddComponent<EnemyMove>());

                }
                else // WaitTime
                {
                    caric.SetDelay(Random.Range(1f, 3f));
                }


    }

    public override void Exit()
    {
    }

    public override void SetAttackState(ENEMYTYPE enemyType)
    {
    }
}
