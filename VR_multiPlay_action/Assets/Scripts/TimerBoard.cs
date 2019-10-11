using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 時間を表示するプログラム、
/// これ自体はTextにアタッチしている、
/// GameControllerにある、_timeを取ってきて表示している
/// </summary>
public class TimerBoard : MonoBehaviour
{
    //変数を宣言
    GameController gameController;
    Text TimerText;

    // Start is called before the first frame update
    void Start()
    {
        //GameControllerのタグがついているオブジェクトをfindしてGameControllerを取得。
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        //自身のTextUIを取得
        TimerText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //制限時間を0詰めで十の位までと小数点第二位までの書式で表示。
        //(0:が桁がない部分は0で埋めるの意味、00.00はそれぞれの桁数を表している)
        TimerText.text = string.Format("{0:00.00}", gameController._time);

        if(gameController._time <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
