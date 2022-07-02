using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireElementAttack : State
{
    FireElement fireElement;
    // start 초기화 용도
    public override void Enter()
    {
        Debug.Log("공격!");

        fireElement = GetComponent<FireElement>();
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();

        caric.anim.Play("Attack");
        Fire();
    }

    // update 역할
    public override void Tick()
    {
    }
    // class에서 나갈 때 쓰임. (거의 안 쓰임)
    public override void Exit()
    {
    }
    void Fire()
    {
        var obj = Instantiate(fireElement.obj_FireElementBullet, transform.position, Quaternion.identity);
        obj.GetComponent<Caric>().Owner = caric;
    }
}
