using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public INGAMESTATE ingameState;

    // Start is called before the first frame update
    void Start()
    {
        ingameState = INGAMESTATE.GROUNDSTATE;
    }

    // Update is called once per frame
    void Update()
    {
        StageEnemyCount();
    }

    void StageEnemyCount()
    {
        switch (ingameState)
        {
            case INGAMESTATE.GROUNDSTATE:
                break;
            case INGAMESTATE.WATERSTATE:
                break;
            case INGAMESTATE.ICESTATE:
                break;
            case INGAMESTATE.LIGHTNINGSTATE:
                break;
            case INGAMESTATE.FIRESTATE:
                break;            
        }

    }
}
