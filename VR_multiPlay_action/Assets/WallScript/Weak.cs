using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weak : MonoBehaviour
{
    public readonly float maxwHP = 1;
    public float wHP;
    private GameObject parent;
    
    
    private void Start()
    {
        parent = transform.root.gameObject;

        Vector3 pos = this.gameObject.transform.position;
        pos.x = Random.Range(-0.5f, 0.5f);
        pos.y = Random.Range(-0.5f, 0.5f);
        pos.x = Random.Range(-0.5f, 0.5f);
        this.gameObject.transform.localPosition = new Vector3(pos.x, pos.y, pos.z);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Bullet")
        {
            wHP -= 1;
        }
    }
    private void Update()
    {

        if (wHP <= 0)
        {
            Destroy(parent);
        }

    }
}
