using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiState : MonoBehaviour
{
    State state;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(state != null)
        {
            state.Tick();
        }
    }

    public void ChangeState(State newState) //사ㅇ태 변경 
    {
        if(state != null)
        {
            state.Exit();
            Destroy(state);
        }

        state = newState;
        state.Enter();
    }
    
}
