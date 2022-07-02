using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    public INGAMESTEP IS = INGAMESTEP.READY;
    public STAGEKIND SK = STAGEKIND.GROUNDSTAGE;
    public GameObject Player = null;
    public int playerKillCount = 0;
    public bool isGameStop = true;
    public bool isBoss = false;


    // public bool isGolem = false;
    // public bool isGolem = false;

    // Start is called before the first frame update
    void Init()
    {
        Player = Resources.Load<GameObject>("Prefab/Player");
    }

    void Start()
    {
        J.Start();
    }

    // Update is called once per frame
    void Update()
    {
        J.Update();

        switch (IS)
        {
            case INGAMESTEP.READY:

                if (!J.BrickManager.BrickSpawn())
                {
                    Debug.Log("Change Playing!!");
                    IS = INGAMESTEP.PLAYING;
                }

                break;

            case INGAMESTEP.PLAYING:

                StageSpawn();

                // if(!isGameStop)
                // {
                //     isGameStop = true;
                //     StartCoroutine(J.SpawnManager.StageCoroutine());
                // }

                break;

            case INGAMESTEP.END:

                break;
        }
    }

    void StageSpawn()
    {
        isGameStop = false;
        StartCoroutine(J.SpawnManager.StageCoroutine());


        

        if (J.IngameManager.playerKillCount >= 15)
        {
            J.IngameManager.ResetKillCount();
            J.SpawnManager.ingameStage = INGAMESTAGE.SECONDSTAGE;
            J.SpawnManager.RoundEnd = true;
        }
        else if (J.IngameManager.playerKillCount >= 20)
        {
            J.IngameManager.ResetKillCount();
            J.SpawnManager.ingameStage = INGAMESTAGE.THIRDSTAGE;
            J.SpawnManager.RoundEnd = true;
        }
        else if (J.IngameManager.playerKillCount >= 30)
        {
            J.IngameManager.ResetKillCount();
            J.SpawnManager.ingameStage = INGAMESTAGE.BOSSSTAGE;
            J.SpawnManager.RoundEnd = true;
        }
        else if (J.IngameManager.playerKillCount >= 1)
        {
            Debug.Log("게임 클리어");
        }
    }

    public void Spawn_Player()
    {

    }

    public void ResetKillCount()
    {
        playerKillCount = 0;
    }
}
