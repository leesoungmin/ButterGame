using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CARICSTATE
{
    IDLE,
    SCAN,
    MOVE,
    ATTACK,
    JUMP,
    FALL,
    HIT,
    DIE,
    DELAY,
}

public enum INGAMESTEP
{
    READY,
    PLAYING,
    END,
}

public enum INGAMESTATE
{ 
    GROUNDSTATE,
    WATERSTATE,
    ICESTATE,
    LIGHTNINGSTATE,
    FIRESTATE,
}


public enum INGAMESTAGE
{
    FIRSTSTAGE,
    SECONDSTAGE,
    THIRDSTAGE,
}

public enum ENEMYPROPERTY
{ 
    GROUND,
    WATER,
    ICE,
    LIGHTNING,
    FIRE,
}


public partial class J : MonoBehaviour
{
    

}
