using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermaid : EnemyBase
{
    public GameObject BubblePrefab = null;
    public GameObject BulletPrefab = null;
    public GameObject BubblePos1 = null;
    public GameObject BubblePos2 = null;
    public GameObject TidePrefab = null;
    public GameObject RedScreen = null;
    public GameObject[] BulletPos = null;
    public override State GetState()
    {
        return gameObject.AddComponent<MermaidAttack>();
    }
    void Update()
    {
        if (Hp <= 0)
        {
            BtnManager.instace.GameClear.SetActive(true);
        }
    }
}
