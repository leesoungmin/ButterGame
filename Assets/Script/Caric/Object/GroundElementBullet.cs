using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundElementBullet : MonoBehaviour
{
    float speed = 4f;

    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        Vector3 vec = Vector3.down;
        transform.Translate(vec * speed * Time.deltaTime);
    }

    void TargetFire()
    {
        var col = Physics.OverlapSphere(transform.position, 20, 1 << (LayerMask.NameToLayer("Player")));
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }
    }
}
