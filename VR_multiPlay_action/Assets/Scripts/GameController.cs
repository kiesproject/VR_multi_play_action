using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    enum State
    {
        Ready,
        Play,
        End
    }

    State state;

    float t = 20.0f;

    public int Target_value = 10;
    [SerializeField] int hitCount = 0;

    bool Attacker_win = false;

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

                if (Input.GetKeyDown(KeyCode.Space)) hitCount++;

                Refereeing();

                t -= Time.deltaTime;
                Debug.Log(t);

                if (t < 0) GameOver();

                break;

            case State.End:
                Debug.Log("End");

                if (Attacker_win)
                {
                    Debug.Log("Attacker Win!!!");
                }
                else
                {
                    Debug.Log("Defender Win!!!");
                }

                if (Input.GetMouseButtonDown(0)) Reload();
                break;
        }
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
        SceneManager.LoadScene("GameManagerTest");
    }

    void Ready()
    {
        state = State.Ready;
    }

    void GameStart()
    {
        state = State.Play;
    }

    void GameOver()
    {
        state = State.End;
    }
}
