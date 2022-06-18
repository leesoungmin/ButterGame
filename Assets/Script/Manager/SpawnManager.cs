using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MONSTERTYPE
{
    LOW,
    MIDDLE,
    HIGH,
}

[System.Serializable]
public class MonsterInfo
{
    public MONSTERTYPE[] monsterType;
    public int[] count;
}

public class SpawnManager : MonoBehaviour
{
    MONSTERTYPE monsterType;
    INGAMESTAGE ingameStage;
    INGAMESTATE ingameState;

    public GameObject[] Ground_Enemies = null;

    //public GameObject Enemy_GroundElement = null;
    public List<GameObject> EnemySpawnPoints = new List<GameObject>();
    public float curSpawnTime = 0;
    public int randomEnemyType = 0;
    public float maxSpawnTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Enemy_GroundElement = Resources.Load<GameObject>("Prefab/GroundElement");

        EnemySpawnPoints = J.Find_Child_List("Point", GameObject.Find("EnemySpawnPoints"));

        curSpawnTime = J.WorldTime;
    }

    // Update is called once per frame
    public void SpawnUpdate()
    {
        
        EnemySpawn();
    }

    public void EnemySpawn()
    {
        if (curSpawnTime <= J.WorldTime)
        {
            EnemyCreate();
        }

    }

    public void EnemyCreate()
    {
        
        randomEnemyType = Random.Range(0, Ground_Enemies.Length);
        GameObject enemies = Instantiate(Ground_Enemies[randomEnemyType]);
        enemies.transform.localPosition = EnemySpawnPoints[Random.Range(0, EnemySpawnPoints.Count)].transform.localPosition;
        enemies.transform.localRotation = Quaternion.identity;

        //GameObject goblin = Instantiate(Enemy_GroundElement); // 브릭 생성
        //goblin.name = "goblin";
        ////goblin.transform.SetParent(Brick_Parent.transform);
        //goblin.transform.localPosition = EnemySpawnPoints[Random.Range(0, EnemySpawnPoints.Count)].transform.localPosition;
        //goblin.transform.localRotation = Quaternion.identity;

        curSpawnTime = J.WorldTime + 4f;

        //Debug.Log("Create Enemy !! " + goblin.name.ToUpper());
    }

}
