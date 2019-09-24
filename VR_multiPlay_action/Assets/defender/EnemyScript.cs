using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float time;
    public bool collide;
    
    void Start()
    {
        time = 0f;
        collide = false;
    }

    //当たった瞬間呼び出される関数
    void OnCollisionEnter(Collision collision)
    {
        collide = true;
        //重力の追加
        gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    void Update()
    {
        if (collide)
        {
            //タイムカウント
            time += Time.deltaTime;
            if (time >= 2f)
            {
                Destroy(gameObject);
            }
        }
    }        
}