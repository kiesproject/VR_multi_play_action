using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weak : MonoBehaviour
{
    public float wHP = 1;
    private GameObject parent;

    Vector3 pos;
    
    private void Start()
    {
        parent = transform.root.gameObject;

        pos.x = Random.Range(-0.5f, 0.5f);
        pos.y = Random.Range(-0.5f, 0.5f);
        pos.x = Random.Range(-0.5f, 0.5f);
        transform.localPosition = new Vector3(pos.x, pos.y, pos.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
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
