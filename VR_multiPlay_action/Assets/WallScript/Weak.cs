using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weak : MonoBehaviour
{
    public float wHP = 1;
    private GameObject parent;

    Vector3 pos;
    [SerializeField] GameObject FX;

    private void Start()
    {
        parent = transform.root.gameObject;

        pos.x = Random.Range(-0.05f, 0.05f);
        pos.y = Random.Range(-0.05f, 0.05f);
        pos.x = Random.Range(-0.05f, 0.05f);
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
            Instantiate(FX, parent.transform.position, parent.transform.rotation);
            Destroy(parent);
        }
    }
}
