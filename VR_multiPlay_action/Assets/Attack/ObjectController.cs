using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float spead = 10;
    Vector3 distance;
    Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
    }
    void Update()
    {
        this.distance = startPos - transform.position;
        float len = distance.magnitude;
        GetComponent<Rigidbody>().AddForce(transform.forward * spead, ForceMode.Force);
        if (len >= 81)
        {
            Destroy(gameObject);
        }
    }
}