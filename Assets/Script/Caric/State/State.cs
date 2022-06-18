using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected AiState aiState;
    protected Caric caric;
    
    public abstract void Enter();
    public abstract void Tick();
    public abstract void Exit(); 
}
