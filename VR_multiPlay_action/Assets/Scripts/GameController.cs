using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController controller;

    enum State
    {
        Ready,
        Play,
        End
    }

    State state;

    public float t = 20.0f;

    [SerializeField] int Target_value = 10;
    [SerializeField] int hitCount = 0;

    bool Attacker_win = false;

    //UI elements
    [SerializeField] Text hitCountBoard;



    private void Awake()
    {
        if (controller == null) controller = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        state = State.Ready;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        switch (state)
        {
            case State.Ready:
                Debug.Log("Ready");

                if (Input.GetMouseButtonDown(0)) GameStart();

                break;

            case State.Play:
                Debug.Log("Play!!");
                Refereeing();
                OnPlaying();

                break;

            case State.End:
                Debug.Log("End");

                if (Input.GetMouseButtonDown(0)) Reload();

                break;
        }
    }

    private void OnPlaying()
    {
        t -= Time.deltaTime;
        //Debug.Log(t);

        if (t < 0) GameOver();
    }

    private void Refereeing()
    {
        if(hitCount >= Target_value)
        {
            Attacker_win = true;
        }
    }

    void Reload()
    {
        SceneManager.LoadScene("Title");
    }

    void Ready()
    {
        state = State.Ready;
    }

    void GameStart()
    {
        state = State.Play;
        SceneManager.LoadScene("GameManagerTest");
    }

    void GameOver()
    {
        state = State.End;
        hitCountBoard = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        hitCountBoard.text = "ヒット回数" + hitCount;
        if (Attacker_win)
        {
            hitCountBoard.text = hitCountBoard.text + "\nAttacker Win!!!";
        }
        else
        {
            hitCountBoard.text = hitCountBoard.text + "\nDefender Win!!!";
        }

        hitCountBoard.enabled = true;
    }

    public void PlayerHit()
    {
        hitCount++;
    }

}
