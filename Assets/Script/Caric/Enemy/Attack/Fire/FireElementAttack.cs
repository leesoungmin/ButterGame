using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireElementAttack : State
{
    FireElement fireElement;
    // start �ʱ�ȭ �뵵
    public override void Enter()
    {
        Debug.Log("����!");

        fireElement = GetComponent<FireElement>();
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();

        caric.anim.Play("Attack");
        Fire();
    }

    // update ����
    public override void Tick()
    {
    }
    // class���� ���� �� ����. (���� �� ����)
    public override void Exit()
    {
    }
    void Fire()
    {
        var obj = Instantiate(fireElement.obj_FireElementBullet, transform.position, Quaternion.identity);
        obj.GetComponent<Caric>().Owner = caric;
    }
}
