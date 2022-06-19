using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : EnemyBase
{
    public override State GetState()
    {
        return gameObject.AddComponent<GroundMoleAttack>();
    }
}
