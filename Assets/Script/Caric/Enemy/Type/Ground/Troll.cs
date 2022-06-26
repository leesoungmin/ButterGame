using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troll : EnemyBase
{
    public override State GetState()
    {
        return gameObject.AddComponent<GroundTrollAttack>();
    }
}
