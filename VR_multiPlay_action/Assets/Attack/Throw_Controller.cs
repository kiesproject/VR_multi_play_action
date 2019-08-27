using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw_Controller : MonoBehaviour
{
    TopCube_Generator topCube;
    LeftCube_Generator leftCube;
    RightCube_Generator rightCube;
    FrontCube_Generator frontCube;
    adjust_Cube_timng adjust;
    float counter;

    // Start is called before the first frame update
    void Start()
    {
        this.topCube = GameObject.Find("TopCube_Generator").GetComponent<TopCube_Generator>();
        this.leftCube = GameObject.Find("LeftCube_Generator").GetComponent<LeftCube_Generator>();
        this.rightCube = GameObject.Find("RightCube_Generator").GetComponent<RightCube_Generator>();
        this.frontCube = GameObject.Find("FrontCube_Generator").GetComponent<FrontCube_Generator>();
        this.adjust = GameObject.Find("adjust_Cube_timing").GetComponent<adjust_Cube_timng>();
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.UpArrow) && counter > adjust.span)
        {
            this.topCube.OnClick();
            adjust.OnClicks();
            counter = 0;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) && counter > adjust.span)
        {
            this.leftCube.OnClick();
            adjust.OnClicks();
            counter = 0;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && counter > adjust.span)
        {
            this.rightCube.OnClick();
            adjust.OnClicks();
            counter = 0;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && counter > adjust.span)
        {
            this.frontCube.OnClick();
            adjust.OnClicks();
            counter = 0;
        }
    }
}
