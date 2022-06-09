using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject Enemy_Goblin = null;
    public List<GameObject> EnemySpawnPoints = new List<GameObject>();
    public float CurSpawnTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        Enemy_Goblin = Resources.Load<GameObject>("Prefab/E_Goblin");

        EnemySpawnPoints = J.Find_Child_List("Point", GameObject.Find("EnemySpawnPoints"));

        CurSpawnTime = J.WorldTime;
    }

    // Update is called once per frame
    public void SpawnUpdate()
    {
        EnemySpawn();
    }

    public void EnemySpawn()
    {
        if(CurSpawnTime <= J.WorldTime)
        {
            EnemyCreate();
        }

    }

    public void EnemyCreate()
    {
        GameObject goblin = Instantiate(Enemy_Goblin); // 브릭 생성
        goblin.name = "goblin";
        //goblin.transform.SetParent(Brick_Parent.transform);
        goblin.transform.localPosition = EnemySpawnPoints[Random.Range(0, EnemySpawnPoints.Count)].transform.localPosition;
        goblin.transform.localRotation = Quaternion.identity;

        CurSpawnTime = J.WorldTime + 4f;

        Debug.Log("Create Enemy !! " + goblin.name.ToUpper());
    }

}
