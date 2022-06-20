using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : State
{

    public override void Enter()
    {
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();

        caric.anim.Play("Hit");

        // hir애니메이션에 ChangeIdle() 이벤트 체크해줘야 됨
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {

    }
}
