using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScan : State
{
    public override void Enter()
    {
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();
        
        caric.isMoleinvcible = false;
        
        Debug.Log("tmzos");
    }

    public override void Tick()
    {
         
            caric.Target_Pos = new Vector2(Random.Range(-8, 8), transform.position.y);
                    
            caric.GetComponent<SpriteRenderer>().flipX = (caric.Target_Pos.x - transform.position.x < 0) ? true : false;
            caric.Direction = (caric.Target_Pos.x - transform.position.x < 0) ? -1 : 1;

            Debug.Log("스캔중");
            
            aiState.ChangeState(gameObject.AddComponent<EnemyMove>());

    }

    public override void Exit()
    {
    }
}
