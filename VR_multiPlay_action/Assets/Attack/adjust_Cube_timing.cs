﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adjust_Cube_timing : MonoBehaviour
{
    public float span = 1.0f;
    public float delta = 0;
    GameObject Front_Button;
    GameObject Left_Button;
    GameObject Right_Button;
    GameObject Top_Button;
    public GameObject GameDirector;

    private void Start()
    {
        this.Front_Button = GameObject.Find("Front_Button");
        this.Left_Button = GameObject.Find("Left_Button");
        this.Right_Button = GameObject.Find("Right_Button");
        this.Top_Button = GameObject.Find("Top_Button");
    }

    public void OnClicks()
    {
        Front_Button.GetComponent<Button>().interactable = false;
        Left_Button.GetComponent<Button>().interactable = false;
        Right_Button.GetComponent<Button>().interactable = false;
        Top_Button.GetComponent<Button>().interactable = false;
        this.delta = 0;
    }

    private void Update()
    {
        if(GameDirector.GetComponent<GameDirector>().time >= 0)
        {
            this.delta += Time.deltaTime;
        }

        if (this.delta >= this.span)
        {
            Front_Button.GetComponent<Button>().interactable = true;
            Left_Button.GetComponent<Button>().interactable = true;
            Right_Button.GetComponent<Button>().interactable = true;
            Top_Button.GetComponent<Button>().interactable = true;

        }

    }
}
