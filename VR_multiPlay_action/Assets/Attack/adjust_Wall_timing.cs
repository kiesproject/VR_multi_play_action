using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class adjust_Wall_timing : MonoBehaviour
{
    public float span = 15.0f;
    float delta = 0;
    GameObject Front_Wall_Button;
    GameObject Left_Wall_Button;
    GameObject Right_Wall_Button;
    GameObject Top_Wall_Button;
    GameObject Slider;
    int minuteCount;

    private void Start()
    {
        this.Front_Wall_Button = GameObject.Find("Front_Wall_Button");
        this.Left_Wall_Button = GameObject.Find("Left_Wall_Button");
        this.Right_Wall_Button = GameObject.Find("Right_Wall_Button");
        this.Top_Wall_Button = GameObject.Find("Top_Wall_Button");
        this.Slider = GameObject.Find("Slider");
        this.Slider.GetComponent<Slider>().maxValue = this.span;
    }

    public void OnClicks()
    {
        Front_Wall_Button.GetComponent<Button>().interactable = false;
        Left_Wall_Button.GetComponent<Button>().interactable = false;
        Right_Wall_Button.GetComponent<Button>().interactable = false;
        Top_Wall_Button.GetComponent<Button>().interactable = false;
        this.Slider.GetComponent<Slider>().value = 0;
        this.minuteCount = 0;
    }

    private void Update()
    {
        this.delta += Time.deltaTime;

        if (this.delta > 1.0f && this.minuteCount <= this.span)
        {
            this.minuteCount++;
            delta = 0;
            this.Slider.GetComponent<Slider>().value++;
            if (this.minuteCount >= this.span)
            {
                Front_Wall_Button.GetComponent<Button>().interactable = true;
                Left_Wall_Button.GetComponent<Button>().interactable = true;
                Right_Wall_Button.GetComponent<Button>().interactable = true;
                Top_Wall_Button.GetComponent<Button>().interactable = true;

                this.minuteCount = 0;
            }
        }

       
    }
}