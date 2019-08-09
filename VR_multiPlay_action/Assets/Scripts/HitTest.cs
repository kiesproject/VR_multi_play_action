using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーにつけるスクリプト、
/// 衝突判定を行っている(テストがてらなので仮)。
/// </summary>
/// 
public class HitTest : MonoBehaviour
{
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        //GameControllerのタグが付いているオブジェクトをFindして、gamecontrollerに代入。
        gameController = GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //何かに当たったらGameControllerのPlayerHitメソッドを呼び出す。
        Debug.Log("Hit!!!!!!!!!!!!!!!!!!!!!");
        gameController.PlayerHit();
    }
}
