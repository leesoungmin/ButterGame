using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWizardAttack : State
{
    FireWizard fireWizard;

    int ranAttack = 0;
    // start 초기화 용도
    public override void Enter()
    {
        ranAttack = Random.Range(0, 3);
        Debug.Log("공격!");
        fireWizard = GetComponent<FireWizard>();
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
        var obj1 = Instantiate(fireWizard.obj_FireWizardBullet, fireWizard.AttackPoint[ranAttack].position, Quaternion.identity);
        ranAttack = Random.Range(0, 3);
        var obj2 = Instantiate(fireWizard.obj_FireWizardBullet, fireWizard.AttackPoint[ranAttack].position, Quaternion.identity);
        obj1.GetComponent<Caric>().Owner = caric;
        obj2.GetComponent<Caric>().Owner = caric;
    }
}
