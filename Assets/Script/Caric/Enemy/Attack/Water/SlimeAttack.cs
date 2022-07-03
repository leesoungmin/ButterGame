using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAttack : State
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            caric.anim.Play("Attack2");
        }
        else if(other.gameObject.tag == "Player")
        {
            aiState.ChangeState(gameObject.AddComponent<EnemyDie>());
        }

    }
}
