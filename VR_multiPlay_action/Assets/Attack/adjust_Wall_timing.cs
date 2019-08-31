using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class adjust_Wall_timing : MonoBehaviour
{
    public float span = 15.0f;
    float delta = 0;
    float UIcounter = 0;
    GameObject Front_Wall_Button;
    GameObject Left_Wall_Button;
    GameObject Right_Wall_Button;
    GameObject Top_Wall_Button;
    GameObject Slider;


    private void Start()
    {
        this.Front_Wall_Button = GameObject.Find("Front_Wall_Button");
        this.Left_Wall_Button = GameObject.Find("Left_Wall_Button");
        this.Right_Wall_Button = GameObject.Find("Right_Wall_Button");
        this.Top_Wall_Button = GameObject.Find("Top_Wall_Button");
        this.Slider = GameObject.Find("Slider");
        this.Slider.GetComponent<Slider>().maxValue = this.span * 5;
    }

    public void OnClicks()
    {
        Front_Wall_Button.GetComponent<Button>().interactable = false;
        Left_Wall_Button.GetComponent<Button>().interactable = false;
        Right_Wall_Button.GetComponent<Button>().interactable = false;
        Top_Wall_Button.GetComponent<Button>().interactable = false;
        this.Slider.GetComponent<Slider>().value = 0;
        this.delta = 0;
    }

    private void Update()
    {
        this.delta += Time.deltaTime;
        this.UIcounter += Time.deltaTime;

        if (this.UIcounter >= 0.2f)
        {
            this.Slider.GetComponent<Slider>().value++;
            UIcounter = 0;
        }


        if (this.delta >= this.span)
        {
            Front_Wall_Button.GetComponent<Button>().interactable = true;
            Left_Wall_Button.GetComponent<Button>().interactable = true;
            Right_Wall_Button.GetComponent<Button>().interactable = true;
            Top_Wall_Button.GetComponent<Button>().interactable = true;
        }
    }
}