using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected AiState aiState;
    protected Caric caric;
    protected EnemyScan enemyScan;
    protected EnemyDelay enemyDelay;
    protected EnemyDie enemyDie;
    protected EnemyHit enemyHit;
    protected EnemyMove enemyMove;
    protected State AttackState;
    protected Player_Main player;
    protected EnemyBase enemy;
    
    public abstract void Enter();
    public abstract void Tick();
    public abstract void Exit(); 
    public abstract void SetAttackState(ENEMYTYPE enemyType);
}
