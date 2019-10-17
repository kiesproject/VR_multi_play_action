using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Throw_Controller : MonoBehaviour
{
    [SerializeField] Generator generator;

    [SerializeField] adjust_Cube_timing adjust;

    [SerializeField] UIDirector uiDirector;

    bool juggiment = false; 

    void Start()
    {

    }


    void Update()
    {
        this.juggiment = false;

        if((Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)))
        {
            this.juggiment = true;
        }
       
        //通常攻撃
        if (Input.GetKeyDown(KeyCode.UpArrow) && this.juggiment == false && uiDirector.frontbutton.interactable == true)
        {
            this.generator.front_OnClick();
            adjust.NomalOnClicks();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && this.juggiment == false && uiDirector.frontbutton.interactable == true)
        {
            this.generator.left_OnClick();
            adjust.NomalOnClicks();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && this.juggiment == false && uiDirector.frontbutton.interactable == true)
        {
            this.generator.right_OnClick();
            adjust.NomalOnClicks();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && this.juggiment == false && uiDirector.frontbutton.interactable == true)
        {
            this.generator.top_OnClick();
            adjust.NomalOnClicks();
        }

        //壁を出す
        else if (Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && uiDirector.Front_Wall_Button.interactable == true)
        {
            this.generator.frontWall_OnClick();
            adjust.WallOnClicks();

        }

        else if (Input.GetKey(KeyCode.LeftArrow) && (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && uiDirector.Front_Wall_Button.interactable == true)
        {
            this.generator.leftWall_OnClick();
            adjust.WallOnClicks();
        }

        else if (Input.GetKey(KeyCode.RightArrow) && (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && uiDirector.Front_Wall_Button.interactable == true)
        {
            this.generator.rightWall_OnClick();
            adjust.WallOnClicks();
        }

        else if (Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && uiDirector.Front_Wall_Button.interactable == true)
        {
            this.generator.topWall_OnClick();
            adjust.WallOnClicks();
        }
    }
}
