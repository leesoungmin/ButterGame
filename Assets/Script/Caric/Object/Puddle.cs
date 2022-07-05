using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puddle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Player_Main>().MoveSpeed = 3f;
            other.GetComponent<Player_Main>().dashSpeed = 15f;
        }
    } 

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.GetComponent<Player_Main>().MoveSpeed = 6f;
            other.GetComponent<Player_Main>().dashSpeed = 30f;
        }
    }

}
