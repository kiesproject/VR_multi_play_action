using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class ResultUIController : MonoBehaviour
{
    [SerializeField] GameObject ResultPanel;
    [SerializeField] Text winnerLabel;

    [SerializeField] Image ScoreImage;
    [SerializeField] Text ratioLabel;

    [SerializeField] int TestScore = 10;
    [SerializeField] int TestTargetScore = 10;

    [Range(0f,1f)][SerializeField] float AnimationValue;

    GameController gameController;

    PlayableDirector playableDirector;
    
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        playableDirector = GetComponent<PlayableDirector>();
        ResultPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.state == GameController.State.End)
        {
            UIChenging();
            ResultPanel.SetActive(true);
            playableDirector.Play();
        }
    }

    private void UIChenging()
    {
        if (gameController.Attacker_win == true)
        {
            winnerLabel.text = "攻撃側の勝利!!!";
        }
        else
        {
            winnerLabel.text = "防御側の勝利!!!";
        }

        ratioLabel.text = gameController.hitCount + "/" + gameController.Target_value;

        float ratio = (float)gameController.hitCount / gameController.Target_value;

        ScoreImage.fillAmount = ratio * 0.5f * AnimationValue;
    }
}
