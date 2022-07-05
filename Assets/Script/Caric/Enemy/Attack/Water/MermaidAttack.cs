using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermaidAttack : State
{
    int ranAttack = 0;

    int curBubbleCnt = 0;
    int maxBubbleCnt = 0;

    Mermaid mermaid;
    public override void Enter()
    {
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();
        mermaid = GetComponent<Mermaid>();

        caric.anim.Play("Attack");

        maxBubbleCnt = Random.Range(3, 5);

        ranAttack = Random.Range(0,5);

        switch (ranAttack)
        {
            case 0:
                StartCoroutine(BulletFire());
                break;
            case 1:
                StartCoroutine(BulletFire2());
                break;
            case 2:
                StartCoroutine(TideAttack());
                break;
            case 3:
                StartCoroutine(TideAttack2());
                break;
            case 4:
                StartCoroutine(BubbleAttack());
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
        yield return new WaitForSeconds(0.3f);
        Instantiate(mermaid.BulletPrefab, mermaid.BulletPos[0].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(mermaid.BulletPrefab, mermaid.BulletPos[1].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(mermaid.BulletPrefab, mermaid.BulletPos[2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(mermaid.BulletPrefab, mermaid.BulletPos[3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }

    IEnumerator BulletFire2()
    {
        yield return new WaitForSeconds(0.3f);
        Instantiate(mermaid.BulletPrefab, mermaid.BulletPos[0].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(mermaid.BulletPrefab, mermaid.BulletPos[1].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(mermaid.BulletPrefab, mermaid.BulletPos[2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(mermaid.BulletPrefab, mermaid.BulletPos[3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        caric.anim.Play("Attack");
        Instantiate(mermaid.BulletPrefab, mermaid.BulletPos[3].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(mermaid.BulletPrefab, mermaid.BulletPos[2].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(mermaid.BulletPrefab, mermaid.BulletPos[1].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.3f);
        Instantiate(mermaid.BulletPrefab, mermaid.BulletPos[0].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }

    IEnumerator TideAttack()
    {
        Instantiate(mermaid.RedScreen, mermaid.RedScreen.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(mermaid.TidePrefab, new Vector3(-8.7f, -3.2f, 0), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }

    IEnumerator TideAttack2()
    {
        Instantiate(mermaid.RedScreen, mermaid.RedScreen.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(mermaid.TidePrefab, new Vector3(-8.7f, -3.2f, 0), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        caric.anim.Play("Attack");
        Instantiate(mermaid.RedScreen, mermaid.RedScreen.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(mermaid.TidePrefab, new Vector3(-8.7f, -3.2f, 0), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }

    IEnumerator BubbleAttack()
    {
        while (curBubbleCnt <= maxBubbleCnt)
        {
            Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 0));
            pos.z = 0.0f;
            Instantiate(mermaid.BubblePrefab, pos, Quaternion.identity);
            curBubbleCnt++;
        }

        yield return new WaitForSeconds(1f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }
}
