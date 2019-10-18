﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestoroy : MonoBehaviour
{
    [SerializeField] float lifeTime = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0) Destroy(this.gameObject);
    }
}
