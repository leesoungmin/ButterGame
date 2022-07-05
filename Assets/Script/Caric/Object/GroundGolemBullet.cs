using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGolemBullet : Caric
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            anim.Play("GolemBulletHit");
        }
        
        if(other.gameObject.tag == "Ground")
        {
            anim.Play("GolemBulletHit");
        }
    }
    public override State GetState()
    {
        throw new System.NotImplementedException();
    }
    
}
