using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundElementAttack : State
{
    GroundElement groundElement;
    public override void Enter()
    {
        Debug.Log("공격!");

        groundElement = GetComponent<GroundElement>();
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();
        
        caric.anim.Play("Attack");
        Fire();
    }

    public override void Tick()
    {
        
        
    }

    public override void Exit()
    {
        
    }

    void Fire()
    {
        var obj = Instantiate(groundElement.obj_GroundElementBulet, transform.position, Quaternion.identity);
        obj.GetComponent<Caric>().Owner = caric;
    }
}
