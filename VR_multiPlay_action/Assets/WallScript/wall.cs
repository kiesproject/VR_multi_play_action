using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public readonly float maxHP = 4;
    public float HP;

    [SerializeField] GameObject FX;

    private void Start()
    {
        HP = maxHP;
    }

    private void Update()
    {
        if (HP <= 0)
        {
            Instantiate(FX, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            HP -= 1;
            Debug.Log("hit!!");
        }
    }

}
