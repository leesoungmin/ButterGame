using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWizard : EnemyBase
{
    public Transform[] AttackPoint;
    [Header("Enemy Bullet Prefabs")]
    public GameObject obj_FireWizardBullet = null;
    public override State GetState()
    {
        return gameObject.AddComponent<FireWizardAttack>();
    }
}
