using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireElement : EnemyBase
{
    [Header("Enemy Bullet Prefabs")]
    public GameObject obj_FireElementBullet = null;
    public override State GetState()
    {
        return gameObject.AddComponent<FireElementAttack>();
    }
}
