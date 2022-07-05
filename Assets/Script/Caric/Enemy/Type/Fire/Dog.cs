using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : EnemyBase
{
    [Header("Enemy Bullet Prefabs")]
    public GameObject obj_FireDogBullet = null;
    public override State GetState()
    {
        return gameObject.AddComponent<FireDogAttack>();
    }
}
