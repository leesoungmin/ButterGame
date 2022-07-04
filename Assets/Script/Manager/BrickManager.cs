using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    private const int TotalBrickCount = 16;
    private int _curBrickCount = 0;

    public float brickCreateTime = 0;

    public GameObject brickParent = null;
    public List<Brick> brickList = new List<Brick>();
    public GameObject brickObj = null;
    public STAGEKIND SK;

    private void Start()
    {
        brickParent = GameObject.Find("Bricks");
        switch(SK)
        {
            case STAGEKIND.GROUNDSTAGE:
                brickObj = Resources.Load<GameObject>("Prefab/Object/GroundBrick"); 
            break;
            case STAGEKIND.WATERSTAGE:
                brickObj = Resources.Load<GameObject>("Prefab/Object/WaterBrick"); 
            break;
            case STAGEKIND.FIRESTAGE:
                brickObj = Resources.Load<GameObject>("Prefab/Object/FireBrick"); 
            break;
        }
        
        brickCreateTime = J.WorldTime;
    }

    public bool BrickSpawn()
    {
        if(_curBrickCount <= TotalBrickCount)
        {
            if(brickCreateTime < J.WorldTime)
            {
                BrickCreate();
            }
        }
        else
        {
            return false;
        }

        return true;
    }

    private void BrickCreate()
    {
        var brick = Instantiate(brickObj); // 브릭 생성
        brick.name = "Brick";
        brick.transform.SetParent(brickParent.transform);
        brick.transform.localPosition = new Vector3(_curBrickCount - 8, 1, 0);
        brick.transform.localScale = Vector3.one;
        brick.transform.localRotation = Quaternion.identity;

        brickList.Add(brick.GetComponent<Brick>());
        brick.GetComponent<Brick>().meNum = _curBrickCount;
        //Debug.Log("브릭 생성 : " + _brickcount);
        
        brickCreateTime = J.WorldTime + 0.15f;
        _curBrickCount++;
    }
}
