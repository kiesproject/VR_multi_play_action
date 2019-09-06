using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    public float time = 70.0f;
    GameObject adjustCube;
    GameObject adjustWall;
    public float remaining_time = 20.0f;


    private void Start()
    {
        this.timerText = GameObject.Find("Time");
        adjustCube = GameObject.Find("adjust_Cube_timing");
        adjustWall = GameObject.Find("adjust_Wall_timing");
    }

    private void Update()
    {
        this.time -= Time.deltaTime;
        if(this.time <= this.remaining_time)
        {
            adjustCube.GetComponent<adjust_Cube_timing>().span = 0.1f;
            adjustWall.GetComponent<adjust_Wall_timing>().span = 3.0f;
        }

        this.timerText.GetComponent<Text>().text =
            this.time.ToString("F1");
    }
}