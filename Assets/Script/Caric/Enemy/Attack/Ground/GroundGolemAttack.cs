using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGolemAttack : State
{
    int ranAttack = 0;
    int ranStoneCount = 0;

    float curBulletCnt = 0;
    float maxBulletCnt = 0;

    bool isStoneSpawnStop = false;
    Golem golem;
    public override void Enter()
    {
        isStoneSpawnStop = false;

        curBulletCnt = 0;

        aiState = GetComponent<AiState>();
        caric = GetComponent<Caric>();
        golem = GetComponent<Golem>();

        maxBulletCnt = Random.Range(10, 16);
        ranStoneCount = Random.Range(10, 17);
        ranAttack = Random.Range(0, 6);

        caric.anim.Play("Attack");

        switch (ranAttack)
        {
            case 0:
                StartCoroutine(StoneSpawn());
                break;
            case 1:
                StartCoroutine(BothFists());
                break;
            case 2:
                StartCoroutine(DownLeftFists());
                break;
            case 3:
                StartCoroutine(DownRightFists());
                break;
            case 4:
                StartCoroutine(DownCenterFists());
                break;
            case 5:
                StartCoroutine(DownDoubleFists());
                break;
        }
    }

    public override void Tick()
    {

    }

    public override void Exit()
    {

    }


    IEnumerator StoneSpawn()
    {
        while (curBulletCnt <= maxBulletCnt)
        {
            Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 0));
            pos.z = 0.0f;
            Instantiate(golem.obj_GroundGolemBullet, pos, Quaternion.identity);
            ++curBulletCnt;
            yield return new WaitForSeconds(0.25f);
        }
        yield return new WaitForSeconds(1f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());

    }

    IEnumerator BothFists()
    {
        Instantiate(golem.obj_RedScreen[0], new Vector3(-5, -1.6f, 0), Quaternion.identity);
        Instantiate(golem.obj_RedScreen[0], new Vector3(5, -1.6f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(golem.obj_GroundGolemFist[0], golem.obj_RedScreen[0].transform.position, Quaternion.identity);
        Instantiate(golem.obj_GroundGolemFist[1], golem.obj_RedScreen[1].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }

    IEnumerator DownLeftFists()
    {
        Instantiate(golem.obj_RedScreen[1], new Vector3(-5, -1.6f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(golem.obj_GroundGolemFist[2], golem.obj_GroundGolemFist[2].transform.position, Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(2f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }

    IEnumerator DownRightFists()
    {
        Instantiate(golem.obj_RedScreen[1], new Vector3(5, -1.6f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(golem.obj_GroundGolemFist[3], golem.obj_GroundGolemFist[3].transform.position, Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(2f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }

    IEnumerator DownCenterFists()
    {
        Instantiate(golem.obj_RedScreen[1], new Vector3(0, -1.6f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(golem.obj_GroundGolemFist[4], golem.obj_GroundGolemFist[4].transform.position, Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(2f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }

    IEnumerator DownDoubleFists()
    {
        Instantiate(golem.obj_RedScreen[1], new Vector3(-5, -1.6f, 0), Quaternion.identity);
        Instantiate(golem.obj_RedScreen[1], new Vector3(5, -1.6f, 0), Quaternion.identity);
        yield return new WaitForSeconds(0.4f);
        Instantiate(golem.obj_GroundGolemFist[2], golem.obj_GroundGolemFist[2].transform.position, Quaternion.Euler(0, 0, 90));
        Instantiate(golem.obj_GroundGolemFist[3], golem.obj_GroundGolemFist[3].transform.position, Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(2f);
        aiState.ChangeState(gameObject.AddComponent<EnemyScan>());
    }
}
