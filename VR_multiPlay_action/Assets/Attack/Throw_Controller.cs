using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Throw_Controller : MonoBehaviour
{
    TopCube_Generator topCube;
    LeftCube_Generator leftCube;
    RightCube_Generator rightCube;
    FrontCube_Generator frontCube;

    TopWall_Generator topWall;
    LeftWall_Generator leftWall;
    RightWall_Generator rightWall;
    FrontWall_Generator frontWall;

    adjust_Cube_timing adjust;
    adjust_Wall_timing adjustWall;
    GameObject Front_Button;
    GameObject Front_Wall_Button;
    bool juggiment = false; 

    void Start()
    {
        this.topCube = GameObject.Find("TopCube_Generator").GetComponent<TopCube_Generator>();
        this.leftCube = GameObject.Find("LeftCube_Generator").GetComponent<LeftCube_Generator>();
        this.rightCube = GameObject.Find("RightCube_Generator").GetComponent<RightCube_Generator>();
        this.frontCube = GameObject.Find("FrontCube_Generator").GetComponent<FrontCube_Generator>();

        this.topWall = GameObject.Find("TopWall_Generator").GetComponent<TopWall_Generator>();
        this.leftWall = GameObject.Find("LeftWall_Generator").GetComponent<LeftWall_Generator>();
        this.rightWall = GameObject.Find("RightWall_Generator").GetComponent<RightWall_Generator>();
        this.frontWall = GameObject.Find("FrontWall_Generator").GetComponent<FrontWall_Generator>();

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
            this.frontCube.OnClick();
            adjust.OnClicks();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && this.juggiment == false && Front_Button.GetComponent<Button>().interactable == true)
        {
            this.leftCube.OnClick();
            adjust.OnClicks();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && this.juggiment == false && Front_Button.GetComponent<Button>().interactable == true)
        {
            this.rightCube.OnClick();
            adjust.OnClicks();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && this.juggiment == false && Front_Button.GetComponent<Button>().interactable == true)
        {
            this.topCube.OnClick();
            adjust.OnClicks();
        }

        //壁を出す
        else if (Input.GetKey(KeyCode.UpArrow) && (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && Front_Wall_Button.GetComponent<Button>().interactable == true)
        {
            this.frontWall.Wall_OnClick();
            adjustWall.OnClicks();

        }

        else if (Input.GetKey(KeyCode.LeftArrow) && (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && Front_Wall_Button.GetComponent<Button>().interactable == true)
        {
            this.leftWall.Wall_OnClick();
            adjustWall.OnClicks();
        }

        else if (Input.GetKey(KeyCode.RightArrow) && (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && Front_Wall_Button.GetComponent<Button>().interactable == true)
        {
            this.rightWall.Wall_OnClick();
            adjustWall.OnClicks();
        }

        else if (Input.GetKey(KeyCode.DownArrow) && (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && Front_Wall_Button.GetComponent<Button>().interactable == true)
        {
            this.topWall.Wall_OnClick();
            adjustWall.OnClicks();

        }
    }
}
