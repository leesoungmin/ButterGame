using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterElement : EnemyBase   
{
    public override State GetState()
    {
        return gameObject.AddComponent<WaterElementAttack>();
    }
}
