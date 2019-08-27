using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adjust_Cube_timng : MonoBehaviour
{
    public float span = 15.0f;
    float delta = 0;
    GameObject Front_Button;
    GameObject Left_Button;
    GameObject Right_Button;
    GameObject Top_Button;
    int minuteCount;

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
        this.minuteCount = 0;
    }

    private void Update()
    {
        this.delta += Time.deltaTime;

        if (this.delta > 1.0f && this.minuteCount <= this.span)
        {
            this.minuteCount++;
            delta = 0;

            if (this.minuteCount >= this.span)
            {
                Front_Button.GetComponent<Button>().interactable = true;
                Left_Button.GetComponent<Button>().interactable = true;
                Right_Button.GetComponent<Button>().interactable = true;
                Top_Button.GetComponent<Button>().interactable = true;

                this.minuteCount = 0;
            }
        }

    }
}
