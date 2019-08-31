using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWall_Generator : MonoBehaviour
{
    public GameObject[] Throw_Object;
    private float lastMovingTime = 0;
    private int dice;
    adjust_Wall_timing timing;


    public void Start()
    {
        this.timing = GameObject.Find("adjust_Wall_timing").GetComponent<adjust_Wall_timing>();
    }

    public void Wall_OnClick()
    {
        if (Time.realtimeSinceStartup - this.lastMovingTime > timing.span)
        {
            this.dice = Random.Range(0, Throw_Object.Length);
            int x = -80;
            int y = 0;
            int z = 0;
            GameObject go = Instantiate(Throw_Object[dice], new Vector3(x, y, z), Quaternion.identity) as GameObject;
            lastMovingTime = Time.realtimeSinceStartup;
        }

    }
}
