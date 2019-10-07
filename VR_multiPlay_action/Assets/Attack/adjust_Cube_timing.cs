﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adjust_Cube_timing : MonoBehaviour
{
    public float span = 1.0f;
    public float delta = 0;

    [SerializeField] UIDirector uiDirector;

    GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void OnClicks()
    {
        uiDirector.frontbutton.interactable = false;
        uiDirector.leftbutton.interactable = false;
        uiDirector.rightbutton.interactable = false;
        uiDirector.topbutton.interactable = false;
        this.delta = 0;
    }

    private void Update()
    {
        if(gameController._time >= 0)
        {
            this.delta += Time.deltaTime;
        }

        float Amount = delta / span;

        uiDirector.frontbutton.image.fillAmount = Amount;
        uiDirector.leftbutton.image.fillAmount = Amount;
        uiDirector.rightbutton.image.fillAmount = Amount;
        uiDirector.topbutton.image.fillAmount = Amount;

        if (this.delta >= this.span)
        {
            uiDirector.frontbutton.interactable = true;
            uiDirector.leftbutton.interactable = true;
            uiDirector.rightbutton.interactable = true;
            uiDirector.topbutton.interactable = true;
        }

    }
}
