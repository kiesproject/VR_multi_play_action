using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float spead = 10;
    Vector3 distance;
    Vector3 startPos;
    public float maxspeed = 1000;
    GameObject Generator;

    private void Start()
    {
        startPos = transform.position;
        Generator = GameObject.Find("Generator");
    }
    void Update()
    {
        this.distance = startPos - transform.position;
        float len = distance.magnitude;

        float speedx = Mathf.Abs(gameObject.GetComponent<Rigidbody>().velocity.x);
        float speedy = Mathf.Abs(gameObject.GetComponent<Rigidbody>().velocity.y);
        float speedz = Mathf.Abs(gameObject.GetComponent<Rigidbody>().velocity.z);

        if(speedx <= maxspeed || speedy <= maxspeed || speedz <= maxspeed)
        GetComponent<Rigidbody>().AddForce(transform.forward * spead, ForceMode.Force);
        if (len >= Generator.GetComponent<Generator>().distance)
        {
            Destroy(gameObject);
        }
    }
}