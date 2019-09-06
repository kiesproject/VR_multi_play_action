using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Front : MonoBehaviour
{
    public float spead = -1;
    void Update()
    {
        transform.Translate(0, 0, spead);   
        if(transform.position.z <= -1)
        {
            Destroy(gameObject);
        }
    }

    
}
