using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left : MonoBehaviour
{
    public float spead = 1;
    void Update()
    {
        transform.Translate(spead, 0, 0);
        if(transform.position.x >= 1)
        {
            Destroy(gameObject);
        }
    }
}
