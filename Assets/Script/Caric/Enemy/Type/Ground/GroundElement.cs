using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundElement : EnemyBase
{
    [Header("Enemy Bullet Prefabs")]
    public GameObject obj_GroundElementBullet = null;
    public override State GetState()
    {
        return gameObject.AddComponent<GroundElementAttack>();
    }
}
