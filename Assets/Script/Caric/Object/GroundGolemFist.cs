using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGolemFist : Caric
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FistDestroy()
    {
        Destroy(gameObject);
    }

    public override State GetState()
    {
        throw new System.NotImplementedException();
    }
}
