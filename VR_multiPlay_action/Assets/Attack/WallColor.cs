using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class WallColor : MonoBehaviour
{
    float span = 1.0f;
    float delta = 0;
    GameObject Front_Wall_Button;
    GameObject Left_Wall_Button;
    GameObject Right_Wall_Button;
    GameObject Top_Wall_Button;
    int minuteCount;

    private void Start()
    {
        this.Front_Wall_Button = GameObject.Find("Front_Wall_Button");
        this.Left_Wall_Button = GameObject.Find("Left_Wall_Button");
        this.Right_Wall_Button = GameObject.Find("Right_Wall_Button");
        this.Top_Wall_Button = GameObject.Find("Top_Wall_Button");
    }

    public void OnClicks()
    {
        Front_Wall_Button.GetComponent<Button>().interactable = false;
        Left_Wall_Button.GetComponent<Button>().interactable = false;
        Right_Wall_Button.GetComponent<Button>().interactable = false;
        Top_Wall_Button.GetComponent<Button>().interactable = false;
    }

    private void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            minuteCount++;
            delta = 0;
        }

        if (minuteCount >= 15)
        {
            Front_Wall_Button.GetComponent<Button>().interactable = true;
            Left_Wall_Button.GetComponent<Button>().interactable = true;
            Right_Wall_Button.GetComponent<Button>().interactable = true;
            Top_Wall_Button.GetComponent<Button>().interactable = true;

            this.minuteCount = 0;
        }
    }
}