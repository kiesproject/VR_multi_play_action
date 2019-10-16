using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlushController : MonoBehaviour
{
    [SerializeField] Image[] images = new Image[4];
    
    [SerializeField] Slider slider;
    public bool once = true;

    void Start()
    {
        foreach(Image image in images)
        {
            image.color = Color.clear;
        }
    }

    void Update()
    {
        if (this.slider.GetComponent<Slider>().value == this.slider.GetComponent<Slider>().maxValue  && this.once == true)
        {
            foreach (Image image in images)
            {
                image.color = new Color(0 / 255f, 255f / 255f, 221f / 255f, 207f / 255f);
            }
            this.once = false;
        }

        for(int i = 0;i < images.Length; i++)
        {
            images[i].color = Color.Lerp(images[i].color, Color.clear, Time.deltaTime);
        }
    }
}
