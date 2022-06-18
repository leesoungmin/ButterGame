using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundElementBullet : MonoBehaviour
{
    float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        var col = Physics.OverlapSphere(transform.position, speed, 1 << (LayerMask.NameToLayer("Player")));
        if(col.Length != 0)
        {
            GameObject target = col[0].gameObject;
            float dis = Vector3.Distance(transform.position, target.transform.position);
            foreach(var found in col)
            {
                float _dis = Vector3.Distance(transform.position, found.transform.position);
                if(_dis < dis)
                {
                    target = found.gameObject;
                    dis = _dis;
                }
            }
            var Dir = (target.transform.position - transform.position).normalized;
            transform.Translate(Dir * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
