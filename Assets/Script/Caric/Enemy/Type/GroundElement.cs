using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundElement : EnemyBase
{
    [Header("Enemy Bullet Prefabs")]
    public GameObject obj_GroundElementBulet = null;

    public override State GetState()
    {
        return gameObject.AddComponent<GroundElementAttack>();
    }
}
