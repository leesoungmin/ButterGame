using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCerberusMeteo : Caric
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"|| other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
    public override State GetState()
    {
        throw new System.NotImplementedException();
    }
}