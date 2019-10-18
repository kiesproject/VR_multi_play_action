using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyCountDown : MonoBehaviour
{
    GameController gameController;
    Text CoutText;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        CoutText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.state == GameController.State.Ready)
        {
            CoutText.enabled = true;
            CoutText.text = gameController.ReadyTime.ToString("N0");
        }
        else if(gameController._time <= 5.0f && tag != "EditorOnly")
        {
            CoutText.enabled = true;
            CoutText.text = gameController._time.ToString("N0");
        }
        else
        {
            CoutText.enabled = false;
        }
    }
}
