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
    public float curSpawnTime = 0;
    public int randomEnemyType = 0;
    public float maxSpawnTime = 0;
    public int randomSpawnDelay = 0;

    //적 카운트
    public int[] maxTypeCount;
    public int curlowCount;
    public int curmiddleCount;
    public int curhighCount;
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
        // if (curSpawnTime <= J.WorldTime)
        // {
        //     EnemyCreate();
        // }

        if (curSpawnTime <= J.WorldTime)
        {
            switch (ingameStage)
            {
                case INGAMESTAGE.FIRSTSTAGE:
                    FirstStageEnemyCreate();
                    break;
                case INGAMESTAGE.SECONDSTAGE:
                    SecondStageEnemyCreate();
                    break;
                case INGAMESTAGE.THIRDSTAGE:
                    ThirdStageEnemyCreate();
                    break;
            }
        }


    }

    public void FirstStageEnemyCreate()
    {
        if (curlowCount <= maxTypeCount[0])
        {
            FirstEnemySpawn();
        }
        else if (curmiddleCount <= maxTypeCount[1])
        {
            SecondEnemySpawn();
        }
        else
        {
            //모든 적들이 소환되었을때(살아있을 수도 있음)
            //끝나면 스테이지 변경
            if (J.IngameManager.playerKillCount >= 13)
            {
                Debug.Log(ingameStage + "모든 적들이 소환되었습니다.");
                ingameStage = INGAMESTAGE.SECONDSTAGE;
                CountReset();
            }

        }
    }
    public void SecondStageEnemyCreate()
    {
        if (curlowCount <= maxTypeCount[2])
        {

            FirstEnemySpawn();
        }
        else if (curmiddleCount <= maxTypeCount[3])
        {

            SecondEnemySpawn();
        }
        else if (curhighCount <= maxTypeCount[4])
        {
            ThirdEnemySpawn();
        }
        else
        {
            //모든 적들이 소환되었을때(살아 있을 수도 있음)
            //끝나면 스테이지 변경
            if (J.IngameManager.playerKillCount >= 19)
            {
                Debug.Log(ingameStage + "모든 적들이 소환되었습니다.");
                ingameStage = INGAMESTAGE.THIRDSTAGE;
                CountReset();
            }

        }
    }
    public void ThirdStageEnemyCreate()
    {
        if (curlowCount <= maxTypeCount[5])
        {
            FirstEnemySpawn();

        }
        else if (curmiddleCount <= maxTypeCount[6])
        {

            SecondEnemySpawn();
        }
        else if (curhighCount <= maxTypeCount[7])
        {

            ThirdEnemySpawn();
        }
        else
        {
            //모든 적들이 소환되었을때(살아 있을 수도 있음)
            //끝나면 스테이지 변경
            if (J.IngameManager.playerKillCount >= 23)
            {
                Debug.Log(ingameStage + "모든 적들이 소환되었습니다.");
                Debug.Log("모든 스테이지가 끝이 났습니다. 이제 보스 스테이지로 갑니다.");
                CountReset();
            }

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

    // 1번째 적 스폰
    public void FirstEnemySpawn()
    {
        GameObject enemy = Instantiate(Ground_Enemies[0]);
        enemy.transform.localPosition = EnemySpawnPoints[Random.Range(0, EnemySpawnPoints.Count)].transform.localPosition;
        enemy.transform.localRotation = Quaternion.identity;

        randomSpawnDelay = Random.Range(4, 8);
        curlowCount += 1;
        curSpawnTime = J.WorldTime + randomSpawnDelay;
    }
    // 2번째 적 스폰
    public void SecondEnemySpawn()
    {
        GameObject enemy = Instantiate(Ground_Enemies[1]);
        enemy.transform.localPosition = EnemySpawnPoints[Random.Range(0, EnemySpawnPoints.Count)].transform.localPosition;
        enemy.transform.localRotation = Quaternion.identity;

        randomSpawnDelay = Random.Range(4, 8);
        curmiddleCount += 1;
        curSpawnTime = J.WorldTime + randomSpawnDelay;
    }

    // 3번째 적 스폰
    public void ThirdEnemySpawn()
    {
        GameObject enemy = Instantiate(Ground_Enemies[2]);
        enemy.transform.localPosition = EnemySpawnPoints[Random.Range(0, EnemySpawnPoints.Count)].transform.localPosition;
        enemy.transform.localRotation = Quaternion.identity;
        randomSpawnDelay = Random.Range(4, 8);

        curhighCount += 1;
        curSpawnTime = J.WorldTime + randomSpawnDelay;
    }

    void CountReset()
    {
        curlowCount = 0;
        curmiddleCount = 0;
        curhighCount = 0;
        J.IngameManager.playerKillCount = 0;
    }

}
