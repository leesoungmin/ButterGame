using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class J : MonoBehaviour
{
    public static float WorldTime = 0;

    public static IngameManager IngameManager = null;
    public static BrickManager BrickManager = null;
    
    public static JudgmentManager JudgmentManager = null;
    public static DestroyManager DestroyManager = null;
    public static SpawnManager SpawnManager = null;

    // Start is called before the first frame update
    public static void Start()
    {
        IngameManager = GameObject.Find("Manager").transform.Find("Ingame").GetComponent<IngameManager>();
        BrickManager = GameObject.Find("Manager").transform.Find("Brick").GetComponent<BrickManager>();
        JudgmentManager = GameObject.Find("Manager").transform.Find("Judgment").GetComponent<JudgmentManager>();
        DestroyManager = GameObject.Find("Manager").transform.Find("Destroy").GetComponent<DestroyManager>();
        SpawnManager = GameObject.Find("Manager").transform.Find("Spawn").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    public static void Update()
    {
        WorldTime = Time.time;
    }
}
