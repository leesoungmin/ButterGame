using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MONSTERTYPE
{
    LOW,
    MIDDLE,
    HIGH,
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
    public GameObject[] Ground_Enemies = null;

    //public GameObject Enemy_GroundElement = null;
    public List<GameObject> EnemySpawnPoints = new List<GameObject>();
    public int randomEnemyType = 0;
    public float maxSpawnTime = 0;

    //적 카운트
    public int[] maxTypeCount;

    void Start()
    {
        //Enemy_GroundElement = Resources.Load<GameObject>("Prefab/GroundElement");

        EnemySpawnPoints = J.Find_Child_List("Point", GameObject.Find("EnemySpawnPoints"));

    }
    public void FirstStageSpawn()
    {
        switch (ingameStage)
        {
            case INGAMESTAGE.FIRSTSTAGE:
                StartCoroutine(EnemySpawn(Ground_Enemies[0], maxTypeCount[0]));
                StartCoroutine(EnemySpawn(Ground_Enemies[1], maxTypeCount[1]));
                if (J.IngameManager.playerKillCount >= 10)
                {
                    CountReset();
                    ingameStage = INGAMESTAGE.SECONDSTAGE;
                }
                break;
            case INGAMESTAGE.SECONDSTAGE:
                StartCoroutine(EnemySpawn(Ground_Enemies[0], maxTypeCount[2]));
                StartCoroutine(EnemySpawn(Ground_Enemies[1], maxTypeCount[3]));
                StartCoroutine(EnemySpawn(Ground_Enemies[2], maxTypeCount[4]));

                if (J.IngameManager.playerKillCount >= 15)
                {
                    CountReset();
                    ingameStage = INGAMESTAGE.THIRDSTAGE;
                }
                break;
            case INGAMESTAGE.THIRDSTAGE:
                StartCoroutine(EnemySpawn(Ground_Enemies[0], maxTypeCount[5]));
                StartCoroutine(EnemySpawn(Ground_Enemies[1], maxTypeCount[6]));
                StartCoroutine(EnemySpawn(Ground_Enemies[2], maxTypeCount[7]));

                if (J.IngameManager.playerKillCount >= 20)
                {
                    Debug.Log("게임 오버");
                }
                break;
        }

    }

    IEnumerator EnemySpawn(GameObject enemy, int maxTypeCount)
    {
        int curCount = 0;
        while (curCount < maxTypeCount)
        {
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            var obj = Instantiate(enemy);
            obj.transform.localPosition = EnemySpawnPoints[Random.Range(0, EnemySpawnPoints.Count)].transform.localPosition;
            obj.transform.localRotation = Quaternion.identity;
            curCount += 1;
            yield return new WaitForSeconds(Random.Range(5f, 9f));
        }

        yield return null;
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
    void CountReset()
    {
        J.IngameManager.playerKillCount = 0;
    }

}
