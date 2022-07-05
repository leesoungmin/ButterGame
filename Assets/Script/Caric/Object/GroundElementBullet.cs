using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundElementBullet : Caric
{
    float speed = 9f;
    public Player_Main player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType(typeof(Player_Main)) as Player_Main;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
         Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
         Vector3 dirVec = player.transform.position - transform.position;
         rigid.AddForce(dirVec.normalized * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }

    public override State GetState()
    {
        throw new System.NotImplementedException();
    }

}
