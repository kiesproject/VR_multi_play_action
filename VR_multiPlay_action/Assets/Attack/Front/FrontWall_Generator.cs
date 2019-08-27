﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWall_Generator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Throw_Object;
    private int dice;
    private float lastMovingTime;


    private void Start()
    {
        this.lastMovingTime = Time.realtimeSinceStartup;
    }

    public void Wall_OnClick()
    {
        if(Time.realtimeSinceStartup - lastMovingTime > 15.0f)
        {
            this.dice = Random.Range(0, Throw_Object.Length);
            int x = 0;
            int y = 0;
            int z = 60;
            GameObject go = Instantiate(Throw_Object[dice], new Vector3(x, y, z), Quaternion.identity) as GameObject;
            this.lastMovingTime = Time.realtimeSinceStartup;
        }
    }
}
