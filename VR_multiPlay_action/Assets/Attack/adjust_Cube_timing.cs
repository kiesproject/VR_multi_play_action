using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adjust_Cube_timing : MonoBehaviour
{
    public float nomal_span = 1.0f;
    public float wall_span = 15.0f;
    public float nomal_delta = 0;
    public float wall_delta = 0;

    [SerializeField] UIDirector uiDirector;

    GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void NomalOnClicks()
    {
        uiDirector.frontbutton.interactable = false;
        uiDirector.leftbutton.interactable = false;
        uiDirector.rightbutton.interactable = false;
        uiDirector.topbutton.interactable = false;

        this.nomal_delta = 0;
    }

    public void WallOnClicks()
    {
        uiDirector.Front_Wall_Button.interactable = false;
        uiDirector.Left_Wall_Button.interactable = false;
        uiDirector.Right_Wall_Button.interactable = false;
        uiDirector.Top_Wall_Button.interactable = false;

        this.wall_delta = 0;
    }

    private void Update()
    {
        if(gameController.state == GameController.State.Play)
        {
            this.nomal_delta += Time.deltaTime;
            this.wall_delta += Time.deltaTime;
        }

        float nomalAmount = nomal_delta / nomal_span;
        float wallAmount = wall_delta / wall_span;

        uiDirector.frontbutton.image.fillAmount = nomalAmount;
        uiDirector.leftbutton.image.fillAmount = nomalAmount;
        uiDirector.rightbutton.image.fillAmount = nomalAmount;
        uiDirector.topbutton.image.fillAmount = nomalAmount;

        uiDirector.Front_Wall_Button.image.fillAmount = wallAmount;
        uiDirector.Left_Wall_Button.image.fillAmount = wallAmount;
        uiDirector.Right_Wall_Button.image.fillAmount = wallAmount;
        uiDirector.Top_Wall_Button.image.fillAmount = wallAmount;

        if (this.nomal_delta >= this.nomal_span)
        {
            uiDirector.frontbutton.interactable = true;
            uiDirector.leftbutton.interactable = true;
            uiDirector.rightbutton.interactable = true;
            uiDirector.topbutton.interactable = true;
        }

        if(this.wall_delta >= this.wall_span)
        {
            uiDirector.Front_Wall_Button.interactable = true;
            uiDirector.Left_Wall_Button.interactable = true;
            uiDirector.Right_Wall_Button.interactable = true;
            uiDirector.Top_Wall_Button.interactable = true;
        }

    }
}
