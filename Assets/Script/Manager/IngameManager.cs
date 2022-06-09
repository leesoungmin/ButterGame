using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : MonoBehaviour
{
    INGAMESTEP IS = INGAMESTEP.READY;
    public GameObject Player = null;

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
    
        switch(IS)
        {
            case INGAMESTEP.READY:
                
                if(!J.BrickManager.BrickSpawn())
                {
                    Debug.Log("Change Playing!!");
                    IS = INGAMESTEP.PLAYING;
                }
                
                break;

            case INGAMESTEP.PLAYING:

                J.SpawnManager.SpawnUpdate();

                break;

            case INGAMESTEP.END:
                
                break;
        }
    }

    public void Spawn_Player()
    {
        
    }

}
