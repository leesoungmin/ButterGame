using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public enum MONSTERTYPE
{
    LOW,
    MIDDLE,
    HIGH,
    BOSS,
}


public class SpawnManager : MonoBehaviour
{

    // [System.Serializable]
    // public class MonsterInfo
    // {
    //     public MONSTERTYPE[] monsterType;
    //     public int[] count;

    // }
    // public MonsterInfo monsterInfo;

    public INGAMESTAGE ingameStage = INGAMESTAGE.FIRSTSTAGE;
    public STAGEKIND stageKind = STAGEKIND.GROUNDSTAGE;
    public List<GameObject> GroundEnemies = new List<GameObject>();
    public List<EnemyBase> EnemiesDestroy = new List<EnemyBase>();
    //public GameObject Enemy_GroundElement = null;
    public List<GameObject> EnemySpawnPoints = new List<GameObject>();
    public int randomEnemyType = 0;
    public float maxSpawnTime = 0;
    public bool RoundEnd = true;
    //적 카운트
    public int[] maxTypeCount;
    List<GameObject> EntytyList = new List<GameObject>();
    public List<Action> RoundFuncList = new List<Action>();

    public int enemyCount = 0;

    void Start()
    {
        //Enemy_GroundElement = Resources.Load<GameObject>("Prefab/GroundElement");

        EnemySpawnPoints = J.Find_Child_List("Point", GameObject.Find("EnemySpawnPoints"));

    }

    public IEnumerator StageCoroutine()
    {

        switch (ingameStage)
        {
            case INGAMESTAGE.FIRSTSTAGE:

                Debug.Log("땅 스테이지 시작");

                
                StartCoroutine(EnemySpawn(GroundEnemies[0], maxTypeCount[0]));
                StartCoroutine(EnemySpawn(GroundEnemies[1], maxTypeCount[1]));
                enemyCount = maxTypeCount[0] + maxTypeCount[1];

                //yield return StartCoroutine(EnemyDie(EntytyList, 15));
                break;
            case INGAMESTAGE.SECONDSTAGE:

                StartCoroutine(EnemySpawn(GroundEnemies[0], maxTypeCount[2]));
                StartCoroutine(EnemySpawn(GroundEnemies[1], maxTypeCount[3]));
                StartCoroutine(EnemySpawn(GroundEnemies[2], maxTypeCount[4]));
                enemyCount = maxTypeCount[2] + maxTypeCount[3] + maxTypeCount[4];

                break;
            case INGAMESTAGE.THIRDSTAGE:

                StartCoroutine(EnemySpawn(GroundEnemies[0], maxTypeCount[5]));
                StartCoroutine(EnemySpawn(GroundEnemies[1], maxTypeCount[6]));
                StartCoroutine(EnemySpawn(GroundEnemies[2], maxTypeCount[7]));
                enemyCount = maxTypeCount[5] + maxTypeCount[6] + maxTypeCount[7];

                break;
            case INGAMESTAGE.BOSSSTAGE:

                StartCoroutine(EnemySpawn(GroundEnemies[3], maxTypeCount[8]));

                break;
        }

        yield return null;
    }

    IEnumerator EnemySpawn(GameObject enemy, int maxTypeCount)
    {
        int curCount = 0;

        while (curCount < maxTypeCount)
        {
            yield return new WaitForSeconds(Random.Range(1f, 3f));
            var obj = Instantiate(enemy);
            EnemiesDestroy.Add(obj.GetComponent<EnemyBase>());
            //EntytyList.Add(obj);
            obj.transform.position = EnemySpawnPoints[Random.Range(0, EnemySpawnPoints.Count)].transform.position;
            obj.transform.localRotation = Quaternion.identity;
            curCount += 1;
            yield return new WaitForSeconds(Random.Range(2f, 5f));
        }
    }


    /*(public void EnemyCreate()
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
    }*/
}
