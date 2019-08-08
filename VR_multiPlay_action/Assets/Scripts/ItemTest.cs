using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTest : MonoBehaviour
{
    Vector3 StartPotision;

    // Start is called before the first frame update
    void Start()
    {
        StartPotision = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        this.transform.position = StartPotision;
    }
}
