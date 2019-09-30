using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Throw_Controller : MonoBehaviour
{
    Generator generator;

    adjust_Cube_timing adjust;
    adjust_Wall_timing adjustWall;
    GameObject Front_Button;
    GameObject Front_Wall_Button;
    bool juggiment = false; 

    void Start()
    {
        this.generator = GameObject.Find("Generator").GetComponent<Generator>();

        this.adjust = GameObject.Find("adjust_Cube_timing").GetComponent<adjust_Cube_timing>();
        this.adjustWall = GameObject.Find("adjust_Wall_timing").GetComponent<adjust_Wall_timing>();
        this.Front_Button = GameObject.Find("Front_Button");
        this.Front_Wall_Button = GameObject.Find("Front_Wall_Button");
    }


    void Update()
    {
        this.juggiment = false;

        if((Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)))
        {
            this.juggiment = true;
        }
       
        //通常攻撃
        if (Input.GetKeyDown(KeyCode.UpArrow) && this.juggiment == false && Front_Button.GetComponent<Button>().interactable == true)
        {
            this.generator.front_OnClick();
            adjust.OnClicks();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && this.juggiment == false && Front_Button.GetComponent<Button>().interactable == true)
        {
            this.generator.left_OnClick();
            adjust.OnClicks();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && this.juggiment == false && Front_Button.GetComponent<Button>().interactable == true)
        {
            this.generator.right_OnClick();
            adjust.OnClicks();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && this.juggiment == false && Front_Button.GetComponent<Button>().interactable == true)
        {
            this.generator.top_OnClick();
            adjust.OnClicks();
        }

        //壁を出す
        else if (Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && Front_Wall_Button.GetComponent<Button>().interactable == true)
        {
            this.generator.frontWall_OnClick();
            adjustWall.OnClicks();

        }

        else if (Input.GetKey(KeyCode.LeftArrow) && (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && Front_Wall_Button.GetComponent<Button>().interactable == true)
        {
            this.generator.leftWall_OnClick();
            adjustWall.OnClicks();
        }

        else if (Input.GetKey(KeyCode.RightArrow) && (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && Front_Wall_Button.GetComponent<Button>().interactable == true)
        {
            this.generator.rightWall_OnClick();
            adjustWall.OnClicks();
        }

        else if (Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && Front_Wall_Button.GetComponent<Button>().interactable == true)
        {
            this.generator.topWall_OnClick();
            adjustWall.OnClicks();

        }
    }
}
