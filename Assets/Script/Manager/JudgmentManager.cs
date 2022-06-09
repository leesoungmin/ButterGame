using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JudgmentSign
{
    public Caric Attacker = null;
    public Caric Defender = null;
    
    public JudgmentSign(Caric _attacker, Caric _defender)
    {
        Attacker = _attacker;
        Defender = _defender;
        J.JudgmentManager.JudgmentSignQueue.Enqueue(this);
    }
}

public class JudgmentManager : MonoBehaviour
{
    public Queue<JudgmentSign> JudgmentSignQueue;
    // Start is called before the first frame update
    void Start()
    {
        JudgmentSignQueue = new Queue<JudgmentSign>();
    }

    // Update is called once per frame
    void Update()
    {
        if(JudgmentSignQueue.Count > 0)
        {
            JudgmentSign judgmentSign = JudgmentSignQueue.Dequeue();
           
            judgmentSign.Defender.Hp -= judgmentSign.Attacker.Dmg;
            
            if(judgmentSign.Defender.Hp <= 0)
            {
                judgmentSign.Defender.Die();
            }
            else
            {
                judgmentSign.Defender.Hit();
            }

            //J.Log("Defender HP : " + Defender.Hp);
        }
    }
}
