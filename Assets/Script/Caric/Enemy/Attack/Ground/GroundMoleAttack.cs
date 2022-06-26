using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoleAttack : State
{
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
