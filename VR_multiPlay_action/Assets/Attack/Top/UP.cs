﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP : MonoBehaviour
{
    public float spead = -1;
    
    void Update()
    {
        transform.Translate(0, spead, 0);
    }
    
}
