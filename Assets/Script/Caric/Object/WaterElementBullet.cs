using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterElementBullet : Caric
{
   float speed = 8f;
    public Player_Main player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType(typeof(Player_Main)) as Player_Main;
        Destroy(gameObject,1.8f);
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
         Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
        //float angle = Mathf.Atan2(dirVec.y, dirVec.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0,0,angle);
        //transform.position += dirVec * speed * Time.deltaTime;
        Vector3 dirVec = player.transform.position - transform.position;
        rigid.AddForce(dirVec.normalized * speed * Time.deltaTime, ForceMode2D.Impulse);
        


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
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
