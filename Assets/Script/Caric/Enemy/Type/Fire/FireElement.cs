using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireElement : EnemyBase
{
    public GameObject waterElementBullet = null;
    public override State GetState()
    {
        return gameObject.AddComponent<WaterElementAttack>();
    }
}
