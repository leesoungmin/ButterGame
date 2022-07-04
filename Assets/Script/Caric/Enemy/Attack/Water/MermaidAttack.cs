using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermaidAttack : State
{
    int ranAttack = 0;

    Mermaid mermaid;
    public override void Enter()
    {
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();
        mermaid = GetComponent<Mermaid>();

        caric.anim.Play("Attack");

        ranAttack = 0;

        switch(ranAttack)
        {
            case 0:
                StartCoroutine(BulletFire());
            break;
            case 1:
                StartCoroutine(TideAttack());
            break;
            case 2:
            break;
        }
    }

    public override void Tick()
    {
    }

    public override void Exit()
    {
        
    }

    IEnumerator BulletFire()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(mermaid.BulletPrefab, mermaid.BulletPos[0].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.7f);
        Instantiate(mermaid.BulletPrefab, mermaid.BulletPos[1].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(mermaid.BulletPrefab, mermaid.BulletPos[2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(mermaid.BulletPrefab, mermaid.BulletPos[3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }

    IEnumerator TideAttack()
    {
        Instantiate(mermaid.RedScreen, mermaid.RedScreen.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(mermaid.TidePrefab, new Vector3(-8.7f,-3.2f,0), Quaternion.identity);
        yield return new WaitForSeconds(2f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }
}
