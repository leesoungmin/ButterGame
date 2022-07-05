using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDogBullet : Caric
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            Debug.Log("우히히히힣");
        }
    }

    public override State GetState()
    {
        throw new System.NotImplementedException();
    }
}
