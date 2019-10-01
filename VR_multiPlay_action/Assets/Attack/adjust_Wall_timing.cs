using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class adjust_Wall_timing : MonoBehaviour
{
    public float span = 15.0f;
    public float delta = 0;
    float UIcounter = 0;
    float a;
    float b;
    GameObject Front_Wall_Button;
    GameObject Left_Wall_Button;
    GameObject Right_Wall_Button;
    GameObject Top_Wall_Button;
    GameObject Slider;
    GameObject flushController;
    public GameObject GameDirector;
    public GameObject adjust_Cube_timing;


    private void Start()
    {
        this.Front_Wall_Button = GameObject.Find("Front_Wall_Button");
        this.Left_Wall_Button = GameObject.Find("Left_Wall_Button");
        this.Right_Wall_Button = GameObject.Find("Right_Wall_Button");
        this.Top_Wall_Button = GameObject.Find("Top_Wall_Button");
        this.Slider = GameObject.Find("Slider");
        this.flushController = GameObject.Find("FlushController");
        this.Slider.GetComponent<Slider>().maxValue = this.span * 5;
        this.a = span / GameDirector.GetComponent<GameDirector>().first_Interval_Wall;
        this.b = span / GameDirector.GetComponent<GameDirector>().second_Interval_Wall;
        
    }

    public void OnClicks()
    {
        Front_Wall_Button.GetComponent<Button>().interactable = false;
        Left_Wall_Button.GetComponent<Button>().interactable = false;
        Right_Wall_Button.GetComponent<Button>().interactable = false;
        Top_Wall_Button.GetComponent<Button>().interactable = false;
        this.Slider.GetComponent<Slider>().value = 0;
        this.delta = 0;
        this.flushController.GetComponent<FlushController>().once = true;
        adjust_Cube_timing.GetComponent<adjust_Cube_timing>().OnClicks();
    }

    private void Update()
    {
        if(GameDirector.GetComponent<GameDirector>().time >= 0)
        {
            this.delta += Time.deltaTime;
            this.UIcounter += Time.deltaTime;
        }

        if (this.UIcounter >= 0.2f && this.Slider.GetComponent<Slider>().value < this.Slider.GetComponent<Slider>().maxValue 
            && GameDirector.GetComponent<GameDirector>().time > GameDirector.GetComponent<GameDirector>().first_remaining_time)
        {
            this.Slider.GetComponent<Slider>().value++;
            UIcounter = 0;

        }

        //first_remaining_timeに突入した際にインターバルを変更する
        if (this.UIcounter >= 0.2f / this.a && this.Slider.GetComponent<Slider>().value < this.Slider.GetComponent<Slider>().maxValue
            && GameDirector.GetComponent<GameDirector>().time <= GameDirector.GetComponent<GameDirector>().first_remaining_time)
        {
            this.Slider.GetComponent<Slider>().value++;
            UIcounter = 0;
        }

        //second_remaining_timeに突入した際にインターバルを変更する
        if (this.UIcounter >= 0.2f / this.b && this.Slider.GetComponent<Slider>().value < this.Slider.GetComponent<Slider>().maxValue
            && GameDirector.GetComponent<GameDirector>().time <= GameDirector.GetComponent<GameDirector>().second_remaining_time)
        {
            this.Slider.GetComponent<Slider>().value++;
            UIcounter = 0;
        }


        if (this.Slider.GetComponent<Slider>().value == this.Slider.GetComponent<Slider>().maxValue)
        {
            Front_Wall_Button.GetComponent<Button>().interactable = true;
            Left_Wall_Button.GetComponent<Button>().interactable = true;
            Right_Wall_Button.GetComponent<Button>().interactable = true;
            Top_Wall_Button.GetComponent<Button>().interactable = true;
        }
    }
}