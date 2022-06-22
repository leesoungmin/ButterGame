using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : State
{
    public override void Enter()
    {
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();
    }

    public override void Tick()
    {
        caric.rigidbody2D.AddForce(Vector2.up * caric.JumpForce);
        caric.IsGround = false;
        aiState.ChangeState(gameObject.AddComponent<PlayerIdle>());
        
    }

    public override void Exit()
    {
    }
}
