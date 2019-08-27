using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    public float spead = -1;
    
    void Update()
    {
        transform.Translate(0, spead, 0);
        if (transform.position.y < -2 )
        {
            Destroy(gameObject);
        }
    }

    
}
