using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : EnemyBase
{
    public GameObject obj_GroundGolemBullet = null;
    public GameObject[] obj_GroundGolemFist = null;
    public GameObject[] obj_RedScreen = null;
    public override State GetState()
    {
        return gameObject.AddComponent<GroundGolemAttack>();
    }
}
