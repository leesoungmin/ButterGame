using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrollAttack : State
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
        if(other.gameObject.tag == "Ground" || other.gameObject.tag == "Player")
        {
            caric.anim.Play("Attack2");
        }

    }

}
