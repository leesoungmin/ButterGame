using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardBullet : Caric
{
    float speed = 8f;
    public Player_Main player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType(typeof(Player_Main)) as Player_Main;
        Destroy(gameObject, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
        rigid.AddForce(transform.up * speed * Time.deltaTime, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("¿ìÈ÷È÷È÷ÆR");
        }
    }

    public override State GetState()
    {
        throw new System.NotImplementedException();
    }
}
