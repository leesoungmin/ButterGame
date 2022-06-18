using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : State
{
    public override void Enter()
    {
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();

        caric.anim.Play("Idle");
        Invoke("ChangeStateScan", 4f);

        Debug.Log("평범한 상태");
        
    }

    public override void Tick()
    {
        
    }

    public override void Exit()
    {
        CancelInvoke("ChangeStateScan");
    }

    void ChangeStateScan()
    {
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());

    }

}
