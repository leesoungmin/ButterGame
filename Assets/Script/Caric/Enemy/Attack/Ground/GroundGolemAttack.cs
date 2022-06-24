using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGolemAttack : State
{
    int ranAttack = 0;
    public override void Enter()
    {
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();

        

        caric.anim.Play("Attack");
    }

    public override void Tick()
    {
    }

    public override void Exit()
    {
    }
}
