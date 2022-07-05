using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDogAttack : State
{
    Dog dog;

    Player_Main player;
    // start �ʱ�ȭ �뵵
    public override void Enter()
    {
        Debug.Log("����!");

        dog = GetComponent<Dog>();
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();

        player = FindObjectOfType(typeof(Player_Main)) as Player_Main;

        caric.anim.Play("Attack");
        Fire();
    }

    public override void Tick()
    {

    }
    public override void Exit()
    {

    }
    void Fire()
    {
        for(int i =0; i < 5; i++)
        {
            var bullet = Instantiate(dog.obj_FireDogBullet,dog.transform.position, Quaternion.identity);
            Rigidbody2D rigidbody2D = bullet.GetComponent<Rigidbody2D>();
            Vector2 dirVec = player.transform.position - dog.transform.position;
            Vector2 ranVec = new Vector2(Random.Range(-2f, 2f), 8);
            dirVec += ranVec;
            rigidbody2D.AddForce(dirVec.normalized * 6f, ForceMode2D.Impulse);
        }
    }
}
