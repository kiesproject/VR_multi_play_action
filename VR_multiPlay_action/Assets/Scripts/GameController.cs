using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


/// <summary>
/// 概要: ゲーム全体のコントロールを行うプログラム、
///       勝利条件の監視、制限時間の減少、ステート状態の管理、hitcountの管理を行う、
/// 　　　ステートには三つあり、Ready、Play、Endでゲームの状態を管理する。
/// 
/// 主な流れ：
/// TitleでReady状態→クリック→MainシーンでPlay状態→制限時間超過→MainシーンでEnd状態→クリック→Titleに戻る。
/// 
/// 
/// </summary>
public class GameController : MonoBehaviour
{
    //自身のインスタンスを入れる変数をStaticで宣言。
    public static GameController controller;

    //  ReadyとPlayとEndの３つのステートを用いる
    enum State
    {
        Ready,
        Play,
        End
    }

    State state;

    //ここで制限時間を宣言している
     public float _time = 20.0f;

    //目標値を宣言
    [SerializeField] int Target_value = 10;
    //hitCount(あたった回数)を初期化
    [SerializeField] int hitCount = 0;

    //攻撃側の勝利フラグ
    bool Attacker_win = false;

    //UI elements
    //[SerializeField] Text hitCountBoard;

    //シーン変遷でゲームコントローラーが消えないようにしている
    private void Awake()
    {
        if (controller == null) controller = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //最初はReadyからスタート
        Ready();
    }

    // Update is called once per frame
    //LateUpdateメソッドはUpdateメソッドの必ず後に処理される
    private void LateUpdate()
    {
        //
        //★プログラムの要の部分、switchとcaseで各状態(State)に沿った処理行う。
        //
        switch (state)
        {
            //最初に来る部分、ボタンを押したらゲームを開始する
            case State.Ready:
                Debug.Log("Ready");

                //GameStartメソッドを呼び出している、これによりシーンをGameManagerTestシーンへ変遷している
                if (Input.GetMouseButtonDown(0)) GameStart();

                break;

            //Play状態では勝ち負けの判定、制限時間の減少を行っている
            case State.Play:
                Debug.Log("Play!!");
                Refereeing();
                OnPlaying();

                break;

            //GameOver時にステートはEndに変更される、勝利した人とヒット回数を表示し、ボタンを押すとリスタートされる。
            case State.End:
                Debug.Log("End");

                //if (Input.GetMouseButtonDown(0)) Reload();

                break;
        }
    }
    

 /// <summary>
 /// ここからは各メソッドの説明を行う
 /// </summary>

    //OnPlayingは制限時間を減少させて、0以下になったらGameOverメソッドを呼び出す
    private void OnPlaying()
    {
        _time -= Time.deltaTime;
        

        if (_time < 0) GameOver();
    }

    //Refereeingは勝利の判定、攻撃側のノルマ達成を判定している
    private void Refereeing()
    {
        if(hitCount >= Target_value)
        {
            Attacker_win = true;
        }
    }

    //ReloadはEndステート時にTitleシーンに移行
    void Reload()
    {
        SceneManager.LoadScene("Title");
    }

    //Awake時にReady状態にする、その他スタート時にやりたい処理はここに追記
    void Ready()
    {
        state = State.Ready;
    }

    //Ready状態の時にボタンを押したら呼び出される、ステートをPlayにし、GameManagerTestシーンに移行
    void GameStart()
    {
        state = State.Play;
        SceneManager.LoadScene("MainScene");
    }

    /// <summary>
    /// OnPlayingの制限時間が0以下になった時に呼び出す、
    /// ステートをEndに変えて、
    /// hitCount(あたった回数)をスコアタグのついているTextUIに表示する、
    /// Textを変えて、勝利した側を表示。
    /// </summary>
    void GameOver()
    {
        state = State.End;

        //hitCountBoard = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        //hitCountBoard.text = "ヒット回数" + hitCount;

        //if (Attacker_win)
        //{
        //    hitCountBoard.text = hitCountBoard.text + "\nAttacker Win!!!";
        //}
        //else
        //{
        //    hitCountBoard.text = hitCountBoard.text + "\nDefender Win!!!";
        //}

        //hitCountBoard.enabled = true;
    }
    
    //外部から呼び出せるようになっている、
    //防御側でアイテムが当たったら呼び出してhitcountを+1する。
    public void PlayerHit()
    {
        hitCount++;
    }
}
