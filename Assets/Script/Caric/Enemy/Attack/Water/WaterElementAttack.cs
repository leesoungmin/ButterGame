using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterElementAttack : State
{
    WaterElement waterElement;
    public override void Enter()
    {
        Debug.Log("공격!");
        
        waterElement = GetComponent<WaterElement>();
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
        var obj = Instantiate(waterElement.waterElementBullet, transform.position, Quaternion.identity);
        obj.GetComponent<Caric>().Owner = caric;
    }
}

