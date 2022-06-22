using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : State
{
    public override void Enter()
    {
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();

        caric.anim.Play("PlayerDie");
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {

    }
}
