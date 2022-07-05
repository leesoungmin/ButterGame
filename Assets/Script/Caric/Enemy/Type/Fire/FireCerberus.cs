using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCerberus : EnemyBase
{
        [Header("Enemy Bullet Prefabs")]
    public GameObject obj_Meteo = null;
    public GameObject obj_Bite = null;
    public GameObject[] RedScreen = null;
    public override State GetState()
    {
        return gameObject.AddComponent<FireCerberusAttack>();
    }
}
