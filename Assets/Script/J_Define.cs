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

public enum INGAMESTAGE
{
    FIRSTSTAGE,
    SECONDSTAGE,
    THIRDSTAGE,
    BOSSSTAGE,
}

public enum STAGEKIND
{
    GROUNDSTAGE,
    WATERSTAGE,
    LIGHTNINGSTAGE,
    FIRSTAGE,
}

public enum ENEMYPROPERTY
{ 
    GROUND,
    WATER,
    ICE,
    LIGHTNING,
    FIRE,
}

public enum ENEMYTYPE
{
    GROUNDELEMENT,
    TROLL,
    MOLE,
    GOLEM,
}


public partial class J : MonoBehaviour
{
    

}
