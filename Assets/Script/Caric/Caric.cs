using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caric : MonoBehaviour
{
    public CARICSTATE CS = CARICSTATE.IDLE;
    public int Hp;
    public int Dmg;
    public float MoveSpeed;
    public float DelayTime;
    public Animator anim = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Die()
    {
        anim.SetBool("Walk", false);
        anim.SetBool("Die", true);
        SetDieDelay(1f);
    }
    public virtual void Hit()
    {   
        anim.SetBool("Walk", false);
        anim.SetTrigger("Hit");
        SetDelay(0.3f);
        Debug.Log("Hp : " + Hp);
    }

    protected void SetDelay(float time)
    {
        CS = CARICSTATE.DELAY;
        DelayTime = J.WorldTime + time;
    }

    private void SetDieDelay(float time)
    {
        CS = CARICSTATE.DIE;
        DelayTime = J.WorldTime + time;
    }

    
}
