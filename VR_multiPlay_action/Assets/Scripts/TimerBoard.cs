using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerBoard : MonoBehaviour
{
    GameController gameController;
    Text TimerText;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        TimerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = string.Format("{0:00.00}", gameController.t);
    }
}
