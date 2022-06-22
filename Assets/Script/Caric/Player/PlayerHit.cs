using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : State
{
    public override void Enter()
    {
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();

        caric.anim.Play("PlayerHit");
    }

    public override void Tick()
    {
    }

    public override void Exit()
    {
    }
}
