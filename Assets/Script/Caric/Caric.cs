using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caric : MonoBehaviour
{
    public CARICSTATE CS = CARICSTATE.IDLE;
    public int Hp = 0;
    public int Dmg = 0;
    public float MoveSpeed = 0;
    public float DelayTime = 0;
    public float Direction = 0;
    public Animator anim = null;
    public float maxAttackTime = 0;
    public float curAttackTime = 0;
    public Vector2 Target_Pos = Vector2.zero;

    protected State state;
    protected AiState aiState;

    // Start is called before the first frame update
    void Start()
    {
        aiState = GetComponent<AiState>();
        state = GetComponent<State>();
        aiState = GetComponent<AiState>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        anim.SetBool("isWalk", false);
        anim.SetBool("isDie", true);
        SetDieDelay(1f);
    }
    public void Hit()
    {   
        anim.SetTrigger("isHit");
        SetDelay(0.3f);
        Debug.Log("Hp : " + Hp);
    }

    public void SetDelay(float time)
    {
        CS = CARICSTATE.DELAY;
        DelayTime = J.WorldTime + time;
    }

    public void SetDieDelay(float time)
    {
        CS = CARICSTATE.DIE;
        DelayTime = J.WorldTime + time;
    }

    
}
