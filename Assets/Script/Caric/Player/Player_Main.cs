using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player_Main : Caric
{

    // Start is called before the first frame update
    void Start()
    {
        aiState = GetComponent<AiState>();

        aiState.ChangeState(gameObject.AddComponent<PlayerIdle>());
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Ground")
        {
            IsGround = true;
        }
    }
    public override State GetState()
    {
        return AttackState;
    }
}

