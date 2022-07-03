using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWizardAttack : State
{
    FireWizard fireWizard;

    int ranAttack = 0;
    // start �ʱ�ȭ �뵵
    public override void Enter()
    {
        ranAttack = Random.Range(0, 3);
        Debug.Log("����!");
        fireWizard = GetComponent<FireWizard>();
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
        var obj1 = Instantiate(fireWizard.obj_FireWizardBullet, fireWizard.AttackPoint[ranAttack].position, Quaternion.identity);
        ranAttack = Random.Range(0, 3);
        var obj2 = Instantiate(fireWizard.obj_FireWizardBullet, fireWizard.AttackPoint[ranAttack].position, Quaternion.identity);
        obj1.GetComponent<Caric>().Owner = caric;
        obj2.GetComponent<Caric>().Owner = caric;
    }
}
