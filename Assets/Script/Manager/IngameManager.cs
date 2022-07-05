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

                if (J.SpawnManager.enemyCount == 0) 
                {
                    StageStart();
                    J.SpawnManager.ingameStage++;
                }

                //StageSpawn();
                
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

    void StageStart()
    {
        isGameStop = false;
        StartCoroutine(J.SpawnManager.StageCoroutine());
    }

    public void ResetKillCount()
    {
        playerKillCount = 0;
    }
}
