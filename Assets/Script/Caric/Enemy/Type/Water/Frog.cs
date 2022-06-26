using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : EnemyBase
{
    public override State GetState()
    {
        return gameObject.AddComponent<FrogAttack>();
    }
}
