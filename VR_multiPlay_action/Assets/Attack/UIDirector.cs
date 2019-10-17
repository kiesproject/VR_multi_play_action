using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIDirector : MonoBehaviour
{
    public GameController gameController;

    float startTime;

    bool juggiment = true;
    bool juggiment2 = true;
    [SerializeField] adjust_Cube_timing adjustCube;

    [SerializeField] Text timerText;

    public Button topbutton;
    public Button leftbutton;
    public Button rightbutton;
    public Button frontbutton;
    public Button Front_Wall_Button;
    public Button Top_Wall_Button;
    public Button Left_Wall_Button;
    public Button Right_Wall_Button;
    
    [SerializeField] Text LastSpurt_UI;
    [SerializeField] Text second_LastSpurt_UI;
    [SerializeField] Text TimeUP_UI;
    [SerializeField] Text Start_UI;
    [SerializeField] Text SpeedUP;
    [SerializeField] Text[] CountDownTexts = new Text[5];

    [SerializeField] GameObject EndAudio;

    float small_scall = 1.0f;
    float big_scall = 1.0f;

    public float first_remaining_time;
    public float first_Interval_Cube;
    public float first_Interval_Wall;
    public float second_remaining_time;
    public float second_Interval_Cube;
    public float second_Interval_Wall;

    private void Awake()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    private void Start()
    {
        startTime = gameController._time;
    }

    
    public void UIcontroller(float standard_time, Text gameUI)
    {
        if (gameController._time <= standard_time && gameController._time >= standard_time - 1.7)
        {
            gameUI.gameObject.SetActive(true);
            if (gameUI.transform.localScale.x <= 1.1f)
            {
                gameUI.transform.localScale = new Vector3(big_scall, big_scall, big_scall);
                this.big_scall *= 1.002f;
            }
        }
        else if (gameController._time < standard_time - 1.7f && gameController._time >= standard_time - 3.0f)
        {
            gameUI.transform.localScale = new Vector3(small_scall, small_scall, small_scall);
            this.small_scall *= 0.8f;
            this.juggiment = true;
        }
        else if (gameController._time < standard_time - 3.0f　&& juggiment == true)
        {
            gameUI.gameObject.SetActive(false);
            this.big_scall = 1.0f;
            this.small_scall = 1.0f;
            juggiment = false;
        }
    }


    //上記のやつを少し変えたやつ
    public void UIcountDown(float standard_time, Text gameUI)
    {
        if (gameController._time <= standard_time && gameController._time >= standard_time - 1.0f)
        {
            gameUI.gameObject.SetActive(true);
            juggiment2 = true;
        }
        else if(gameController._time < standard_time - 1.0f && juggiment2 == true)
        {
            gameUI.gameObject.SetActive(false);
            juggiment2 = false;
        }
    }



    private void Update()
    {
        //ゲーム開始のUIを画面上に表示する
        if(gameController.state == GameController.State.Play && gameController._time >= startTime - 3.1f)
        {
            UIcontroller(startTime, Start_UI);
        }

        //一つ目に設定した残り時間になったことをUIで表示する
        if(gameController._time <= first_remaining_time && gameController._time >= first_remaining_time - 3.1f)
        {
            UIcontroller(first_remaining_time, LastSpurt_UI);
        }

        if(gameController._time <= first_remaining_time - 3.1f && gameController._time >= first_remaining_time - 6.2f)
        {
            UIcontroller(first_remaining_time - 3.1f, SpeedUP);
        }

        //一つ目に設定した残り時間になった時、インターバルを変更する
        if (gameController._time <= first_remaining_time)
        {
            adjustCube.nomal_span = first_Interval_Cube;
            adjustCube.wall_span = first_Interval_Wall;
        }

        //二つ目に設定した残り時間になったことをUIで表示する
        if(gameController._time <= second_remaining_time && gameController._time >= second_remaining_time - 3.1f)
        {
            UIcontroller(second_remaining_time, second_LastSpurt_UI);
        }

        if(gameController._time <= second_remaining_time - 3.1f && gameController._time >= second_remaining_time - 6.2f)
        {
            UIcontroller(second_remaining_time - 3.1f, SpeedUP);
        }

        //二つ目に設定した残り時間になった時、インターバルを変更する
        if (gameController._time <= second_remaining_time)
        {
            adjustCube.nomal_span = second_Interval_Cube;
            adjustCube.wall_span = second_Interval_Wall;
        }

        if(gameController._time <= 5.0f)
        {
            EndAudio.SetActive(true);
        }

        //カウントダウンをUIで表示する
        if(gameController._time <= 5.5f && gameController._time >= 3.0f)
        {
            UIcountDown(5.0f, CountDownTexts[0]);
            juggiment = true;
        }

        if (gameController._time <= 4.5f && gameController._time >= 2.0f)
        {
            UIcountDown(4.0f, CountDownTexts[1]);
        }

        if (gameController._time <= 3.5f && gameController._time >= 1.0f)
        {
            UIcountDown(3.0f, CountDownTexts[2]);
        }

        if (gameController._time <= 2.5f && gameController._time >= 0.0f)
        {
            UIcountDown(2.0f, CountDownTexts[3]);
        }

        if (gameController._time <= 1.5f && gameController._time >= -1.0f)
        {
            UIcountDown(1.0f, CountDownTexts[4]);
        }


        //バトル終了時、バトル終了を知らせるUIを画面上に表示する
        if (gameController._time <= 0 && gameController._time >= 0 - 3.1f)
        {
            UIcontroller(0, TimeUP_UI);
        }


        //残り時間を右上に常時表示する
        this.timerText.text = gameController._time.ToString("F1");

      　//残り時間が0になったら止める処理
        if(gameController.state == GameController.State.End)
        {
            timerText.GetComponent<Text>().text = "0.0";
            topbutton.interactable = false;
            frontbutton.interactable = false;
            leftbutton.interactable = false;
            rightbutton.interactable = false;
            Top_Wall_Button.interactable = false;
            Left_Wall_Button.interactable = false;
            Right_Wall_Button.interactable = false;
            Front_Wall_Button.interactable = false;

            adjustCube.nomal_delta = 0;

            if (juggiment == true)
            {
                juggiment = false;
            }
        }
    }
}