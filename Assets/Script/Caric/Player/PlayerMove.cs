using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : State
{
    public override void Enter()
    {
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();

        caric.anim.Play("PlayerMove");
    }

    public override void Tick()
    {
        if (caric.x == 0)
        {
            aiState.ChangeState(gameObject.AddComponent<PlayerIdle>());
        }



        if (caric.x > 0)
        {
            caric.spriteRenderer.flipX = false;
        }
        else if (caric.x < 0)
        {
            caric.spriteRenderer.flipX = true;
        }
        this.transform.Translate(new Vector2(caric.MoveSpeed * caric.x * Time.deltaTime, 0));

        if (Input.GetKeyDown(KeyCode.Space) && caric.IsGround)
        {
            caric.anim.Play("PlayerJump");
            caric.rigidbody2D.AddForce(Vector2.up * caric.JumpForce);
            caric.IsGround = false;
        }
        else
        {
        caric.x = Input.GetAxis("Horizontal");

        }
    }

    public override void Exit()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Brick"))
        {
            StartCoroutine(Gravity());
        }
    }

    IEnumerator Gravity()
    {
            caric.rigidbody2D.gravityScale = 10;
            yield return new WaitForSeconds(0.1f);
            caric.rigidbody2D.gravityScale = 4;
    }
}
