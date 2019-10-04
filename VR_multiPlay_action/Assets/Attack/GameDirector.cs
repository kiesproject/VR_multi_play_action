using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    public float time;
    float time1;
    bool juggiment = true;
    bool juggiment2 = true;
    GameObject adjustCube;
    GameObject adjustWall;
    GameObject topbutton;
    GameObject leftbutton;
    GameObject rightbutton;
    GameObject frontbutton;
    GameObject Front_Wall_Button;
    GameObject Top_Wall_Button;
    GameObject Left_Wall_Button;
    GameObject Right_Wall_Button;
    GameObject Slider;
    public float first_remaining_time;
    public float first_Interval_Cube;
    public float first_Interval_Wall;
    public float second_remaining_time;
    public float second_Interval_Cube;
    public float second_Interval_Wall;
    float small_scall = 1.0f;
    float big_scall = 1.0f;
    public GameObject LastSpurt_UI;
    public GameObject second_LastSpurt_UI;
    public GameObject TimeUP_UI;
    public GameObject Start_UI;
    public GameObject SpeedUP;
    public GameObject SpeedUP2;
    public GameObject CountDown_5;
    public GameObject CountDown_4;
    public GameObject CountDown_3;
    public GameObject CountDown_2;
    public GameObject CountDown_1;
    public GameObject adjust_Cube_timing;
    public GameObject adjust_Wall_timing;



    private void Start()
    {
        this.timerText = GameObject.Find("Time");
        adjustCube = GameObject.Find("adjust_Cube_timing");
        adjustWall = GameObject.Find("adjust_Wall_timing");
        frontbutton = GameObject.Find("Front_Button");
        leftbutton = GameObject.Find("Left_Button");
        rightbutton = GameObject.Find("Right_Button");
        topbutton = GameObject.Find("Top_Button");
        Top_Wall_Button = GameObject.Find("Top_Wall_Button");
        Left_Wall_Button = GameObject.Find("Left_Wall_Button");
        Right_Wall_Button = GameObject.Find("Right_Wall_Button");
        Front_Wall_Button = GameObject.Find("Front_Wall_Button");
        this.Slider = GameObject.Find("Slider");
        time1 = time;
    }

    
    public void UIcontroller(float standard_time, GameObject gameUI)
    {
        if (time <= standard_time && time >= standard_time - 1.7)
        {
            gameUI.SetActive(true);
            if (gameUI.transform.localScale.x <= 1.1f)
            {
                gameUI.transform.localScale = new Vector3(big_scall, big_scall, big_scall);
                this.big_scall *= 1.002f;
            }
        }
        else if (time < standard_time - 1.7f && time >= standard_time - 3.0f)
        {
            gameUI.transform.localScale = new Vector3(small_scall, small_scall, small_scall);
            this.small_scall *= 0.8f;
            this.juggiment = true;
        }
        else if (time < standard_time - 3.0f　&& juggiment == true)
        {
            gameUI.SetActive(false);
            this.big_scall = 1.0f;
            this.small_scall = 1.0f;
            juggiment = false;
        }
    }


    //上記のやつを少し変えたやつ
    public void UIcountDown(float standard_time, GameObject gameUI)
    {
        if (time <= standard_time && time >= standard_time - 1.0f)
        {
            gameUI.SetActive(true);
            juggiment2 = true;
        }
        else if(time < standard_time - 1.0f && juggiment2 == true)
        {
            Destroy(gameUI);
            juggiment2 = false;
        }
    }



    private void Update()
    {
        if(time >= -3.5f)
        {
            time -= Time.deltaTime;
        }

        //ゲーム開始のUIを画面上に表示する
        if(time <= time1 && time >= time1 - 3.1f)
        {
            UIcontroller(time1, Start_UI);
        }

        //一つ目に設定した残り時間になったことをUIで表示する
        if(time <= first_remaining_time && time >= first_remaining_time - 3.1f)
        {
            UIcontroller(first_remaining_time, LastSpurt_UI);
        }

        if(time <= first_remaining_time - 3.1f && time >= first_remaining_time - 6.2f)
        {
            UIcontroller(first_remaining_time - 3.1f, SpeedUP);
        }

        //一つ目に設定した残り時間になった時、インターバルを変更する
        if (time <= first_remaining_time)
        {
            adjustCube.GetComponent<adjust_Cube_timing>().span = first_Interval_Cube;
            adjustWall.GetComponent<adjust_Wall_timing>().span = first_Interval_Wall;
        }

        //二つ目に設定した残り時間になったことをUIで表示する
        if(time <= second_remaining_time && time >= second_remaining_time - 3.1f)
        {
            UIcontroller(second_remaining_time, second_LastSpurt_UI);
        }

        if(time <= second_remaining_time - 3.1f && time >= second_remaining_time - 6.2f)
        {
            UIcontroller(second_remaining_time - 3.1f, SpeedUP2);
        }

        //二つ目に設定した残り時間になった時、インターバルを変更する
        if (time <= second_remaining_time)
        {
            adjustCube.GetComponent<adjust_Cube_timing>().span = second_Interval_Cube;
            adjustWall.GetComponent<adjust_Wall_timing>().span = second_Interval_Wall;
        }

        //カウントダウンをUIで表示する
        if(time <= 5.5f && time >= 3.0f)
        {
            UIcountDown(5.0f, CountDown_5);
            juggiment = true;
        }

        if (time <= 4.5f && time >= 2.0f)
        {
            UIcountDown(4.0f, CountDown_4);
        }

        if (time <= 3.5f && time >= 1.0f)
        {
            UIcountDown(3.0f, CountDown_3);
        }

        if (time <= 2.5f && time >= 0.0f)
        {
            UIcountDown(2.0f, CountDown_2);
        }

        if (time <= 1.5f && time >= -1.0f)
        {
            UIcountDown(1.0f, CountDown_1);
        }


        //バトル終了時、バトル終了を知らせるUIを画面上に表示する
        if (time <= 0 && time >= 0 - 3.1f)
        {
            UIcontroller(0, TimeUP_UI);
        }


        //残り時間を右上に常時表示する
        this.timerText.GetComponent<Text>().text =
            time.ToString("F1");

      　//残り時間が0になったら止める処理
        if(time <= 0)
        {
            timerText.GetComponent<Text>().text = "0.0";
            topbutton.GetComponent<Button>().interactable = false;
            frontbutton.GetComponent<Button>().interactable = false;
            leftbutton.GetComponent<Button>().interactable = false;
            rightbutton.GetComponent<Button>().interactable = false;
            Top_Wall_Button.GetComponent<Button>().interactable = false;
            Left_Wall_Button.GetComponent<Button>().interactable = false;
            Right_Wall_Button.GetComponent<Button>().interactable = false;
            Front_Wall_Button.GetComponent<Button>().interactable = false;
            adjust_Cube_timing.GetComponent<adjust_Cube_timing>().delta = 0;
            adjust_Wall_timing.GetComponent<adjust_Wall_timing>().delta = 0;

            if (juggiment == true)
            {
                this.Slider.SetActive(false);
                juggiment = false;
            }
        }

    }
}