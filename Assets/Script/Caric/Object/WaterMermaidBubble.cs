using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMermaidBubble : Caric
{
   float speed = 5f;

   public GameObject Puddle = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            anim.Play("BubbleBoom");
            Debug.Log("우히히히힣");
        }
        else if(other.gameObject.tag == "Ground")
        {
            anim.Play("BubbleBoom");
            Instantiate(Puddle, gameObject.transform.position, Quaternion.identity);
        }
        
    }

    public override State GetState()
    {
        throw new System.NotImplementedException();
    }
}
