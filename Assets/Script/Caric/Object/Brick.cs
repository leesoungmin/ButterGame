using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public Rigidbody2D rigid = null;

    public Caric attacker = null;
    public List<Caric> defenders = new List<Caric>();
    public int meNum;

    public bool isAttack = false;


    // Start is called before the first frame update
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.DrawRay(transform.localPosition, (gameObject.transform.up * -1) * 1f, Color.blue, 0.3f);
        BrickFix();
    }

    private void BrickFix()
    {
        if(transform.localPosition.y <= 1)
        {
            gameObject.transform.localPosition = new Vector2(transform.localPosition.x, 1);
            rigid.gravityScale = 0;
            rigid.velocity = new Vector2(0, 0);
        }
        else
        {
            rigid.gravityScale = 4f;
            //rigid.velocity = new Vector2(0, 0);
        }
    }
    
    void CheckLeftSideBrick()
    {   
        if(J.BrickManager.brickList[meNum - 1] == null) return;
        
        J.BrickManager.brickList[meNum - 1].attacker = null;
    }
    
    void CheckRightSideBrick()
    {
        if(J.BrickManager.brickList[meNum + 1] == null) return; 
        
        J.BrickManager.brickList[meNum + 1].attacker = null;        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            var hit = Physics2D.Raycast(transform.localPosition, gameObject.transform.up * -1, 1f, LayerMask.GetMask("Player"));
            
            if(hit.collider != null)
            { 
                Debug.Log(hit.collider.name);
                attacker = other.gameObject.GetComponent<Caric>();
            }
        }

        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            
            defenders.Add(other.gameObject.GetComponent<Caric>());
            
        }
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (attacker == null) return;
            
            foreach(var defender in defenders)
            {
                new JudgmentSign(attacker, defender);
            }
            
            attacker = null;
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            defenders.Remove(other.gameObject.GetComponent<Caric>());
        }

        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            attacker = null;
        }
    }
}
