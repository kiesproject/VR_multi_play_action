using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float spead = 10;
    Vector3 distance;
    Vector3 startPos;
    public float maxspeed = 1000;

    Generator generator;
    GameController gameController;

    Rigidbody rigidbody;

    bool hitFlag = false;
    [SerializeField] float lifeTime = 5.0f;

    private void Start()
    {
        startPos = transform.position;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        generator = GameObject.FindGameObjectWithTag("Generator").GetComponent<Generator>();
        rigidbody = GetComponent<Rigidbody>();
        
    }
    void Update()
    {
        this.distance = startPos - transform.position;
        float len = distance.magnitude;

        float speedx = Mathf.Abs(rigidbody.velocity.x);
        float speedy = Mathf.Abs(rigidbody.velocity.y);
        float speedz = Mathf.Abs(rigidbody.velocity.z);

        if(hitFlag == false)
        {
            if (speedx <= maxspeed || speedy <= maxspeed || speedz <= maxspeed)
            {
                rigidbody.AddForce(transform.forward * spead * Time.deltaTime, ForceMode.Force);
            }
        }
        else
        {
            lifeTime -= Time.deltaTime;
            if(lifeTime < 0)
            {
                Destroy(this.gameObject);
            }
        }

        if (len >= generator.GetComponent<Generator>().distance)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            hitFlag = true;
            rigidbody.useGravity = true;
            gameController.PlayerHit();
        }
    }
}