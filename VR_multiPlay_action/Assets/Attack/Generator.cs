using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public int distance = 60;
    public GameObject[] Throw_Object;
    private int dice;
    public GameObject[] wall_Throw_Object;
    private float lastMovingTime = 0;
    private int wall_dice;
    [SerializeField] adjust_Cube_timing timing;

    private void Start()
    {

    }

    public void OnClick(int a, int b, int c, float d, float e, float f)
    {
        this.dice = Random.Range(0, Throw_Object.Length);
        int x = a;
        int y = b;
        int z = c;
        GameObject go = Instantiate(Throw_Object[dice], new Vector3(x, y, z), Quaternion.Euler(d, e, f)) as GameObject;
    }

    public void Wall_OnClick(int a, int b, int c, float d, float e, float f)
    {
        if (Time.realtimeSinceStartup - this.lastMovingTime > timing.wall_span)
        {
            this.wall_dice = Random.Range(0, wall_Throw_Object.Length);
            int x = a;
            int y = b;
            int z = c;
            GameObject go = Instantiate(wall_Throw_Object[wall_dice], new Vector3(x, y, z), Quaternion.Euler(d, e, f)) as GameObject;
            lastMovingTime = Time.realtimeSinceStartup;
        }
    }

    public void front_OnClick()
    {
        OnClick(Random.Range(-1, 2), Random.Range(-1, 2), distance, 0f, 180f, 0f);
    }

    public void top_OnClick()
    {
        OnClick(Random.Range(-1, 2), distance, Random.Range(-1, 2), 90f, 0f, 0f);
    }

    public void left_OnClick()
    {
        OnClick(-distance, Random.Range(-1, 2), Random.Range(-1, 2), 0f, 90f, 0f);
    }

    public void right_OnClick()
    {
        OnClick(distance, Random.Range(-1, 2), Random.Range(-1, 2), 0f, -90f, 0f);
    }

    public void frontWall_OnClick()
    {
        Wall_OnClick(0, 0, distance, 0f, 180f, 0f);
    }

    public void topWall_OnClick()
    {
        Wall_OnClick(0, distance, 0, 90f, 0f, 0f);
    }

    public void rightWall_OnClick()
    {
        Wall_OnClick(distance, 0, 0, 0f, -90f, 0f);
    }

    public void leftWall_OnClick()
    {
        Wall_OnClick(-distance, 0, 0, 0f, 90f, 0f);
    }

}