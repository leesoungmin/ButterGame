using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMermaidTide : Caric
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TideMove();
        if(transform.position.x >= 8.8f)
        {
            Destroy(gameObject);
        }
    }

    void TideMove()
    {
        transform.Translate(Vector2.right * 5 * Time.deltaTime, 0);
    }

    public override State GetState()
    {
        throw new System.NotImplementedException();
    }
}
