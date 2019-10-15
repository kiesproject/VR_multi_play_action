using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public readonly float maxHP = 4;
    public float HP;

    private void Start()
    {
        HP = maxHP;
    }

    private void Update()
    {
        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Bullet")
        {
            HP -= 1;
        }
    }
}
