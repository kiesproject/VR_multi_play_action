using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlushController : MonoBehaviour
{
    GameObject img1;
    GameObject img2;
    GameObject img3;
    GameObject img4;
    GameObject slider;
    public bool once = true;

    void Start()
    {
        this.img1 = GameObject.Find("Flush_right");
        this.img2 = GameObject.Find("Flush_left");
        this.img3 = GameObject.Find("Flush_up");
        this.img4 = GameObject.Find("Flush_bottom");


        this.slider = GameObject.Find("Slider");

        img1.GetComponent<Image>().color = Color.clear;
        img2.GetComponent<Image>().color = Color.clear;
        img3.GetComponent<Image>().color = Color.clear;
        img4.GetComponent<Image>().color = Color.clear;

    }

    void Update()
    {
        if (this.slider.GetComponent<Slider>().value == this.slider.GetComponent<Slider>().maxValue  && this.once == true)
        {
            this.img1.GetComponent<Image>().color = new Color(0 / 255f, 255f / 255f, 221f / 255f, 207f / 255f);
            this.img2.GetComponent<Image>().color = new Color(0 / 255f, 255f / 255f, 221f / 255f, 207f / 255f);
            this.img3.GetComponent<Image>().color = new Color(0 / 255f, 255f / 255f, 221f / 255f, 207f / 255f);
            this.img4.GetComponent<Image>().color = new Color(0 / 255f, 255f / 255f, 221f / 255f, 207f / 255f);

            this.once = false;
        }

        this.img1.GetComponent<Image>().color = Color.Lerp(this.img1.GetComponent<Image>().color, Color.clear, Time.deltaTime);
        this.img2.GetComponent<Image>().color = Color.Lerp(this.img2.GetComponent<Image>().color, Color.clear, Time.deltaTime);
        this.img3.GetComponent<Image>().color = Color.Lerp(this.img3.GetComponent<Image>().color, Color.clear, Time.deltaTime);
        this.img4.GetComponent<Image>().color = Color.Lerp(this.img4.GetComponent<Image>().color, Color.clear, Time.deltaTime);
    }
}
