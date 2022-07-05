using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCerberusAttack : State
{
    int ranAttack = 0;

    float curBulletCnt = 0;
    float maxBulletCnt = 0;
    FireCerberus cerberus;

    public override void Enter()
    {
        Debug.Log("����!");
        cerberus = GetComponent<FireCerberus>();
        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();

        ranAttack = Random.Range(0,5);
        maxBulletCnt = Random.Range(10, 17);


        switch (ranAttack)
        {
            case 0:
                caric.anim.Play("MeteoAttack");
                StartCoroutine(MeteoAttack());
                break;
            case 1:
                caric.anim.Play("BiteAttack");
                StartCoroutine(BiteCenter());
                break;
            case 2:
                caric.anim.Play("BiteAttack");
                StartCoroutine(BiteBoth());
                break;
            case 3:
                caric.anim.Play("BiteAttack");
                StartCoroutine(BiteLeft());
                break;
            case 4:
                caric.anim.Play("BiteAttack");
                StartCoroutine(BiteRight());
                break;
        }

    }

    public override void Tick()
    {

    }
    public override void Exit()
    {
        
    }

    IEnumerator MeteoAttack()
    {
        while (curBulletCnt <= maxBulletCnt)
        {
            Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 0));
            pos.z = 0.0f;
            Instantiate(cerberus.obj_Meteo, pos, Quaternion.identity);
            ++curBulletCnt;
            yield return new WaitForSeconds(0.25f);
        }
        yield return new WaitForSeconds(1f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }

    IEnumerator BiteCenter()
    {
        Instantiate(cerberus.RedScreen[0], new Vector3(0, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(cerberus.obj_Bite, new Vector3(0,0,0), Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(2f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }

    IEnumerator BiteLeft()
    {
        Instantiate(cerberus.RedScreen[1], new Vector3(-4, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(cerberus.obj_Bite, new Vector3(-4,0,0), Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(2f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }

    IEnumerator BiteRight()
    {
        Instantiate(cerberus.RedScreen[2], new Vector3(4, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(cerberus.obj_Bite, new Vector3(4,0,0), Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(2f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }

    IEnumerator BiteBoth()
    {
        Instantiate(cerberus.RedScreen[2], new Vector3(4, 0, 0), Quaternion.identity);
        Instantiate(cerberus.RedScreen[1], new Vector3(-4, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(cerberus.obj_Bite, new Vector3(4,0,0), Quaternion.Euler(0, 0, 90));
        Instantiate(cerberus.obj_Bite, new Vector3(-4,0,0), Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(2f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }
}
