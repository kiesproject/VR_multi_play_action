using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] float spead = 10;
    [SerializeField] float maxspeed = 1000;

    Vector3 distance;
    Vector3 startPos;

    Generator generator;
    GameController gameController;

    Rigidbody rigidbody;

    Transform ParentTransform;

    bool hitFlag = false;
    [SerializeField] float lifeTime = 5.0f;

    [SerializeField] Vector3 RotateAngle = Vector3.zero;

    private void Start()
    {
        ParentTransform = transform.root;

        startPos = ParentTransform.position;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        generator = GameObject.FindGameObjectWithTag("Generator").GetComponent<Generator>();
        rigidbody = ParentTransform.gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        
        this.distance = startPos - ParentTransform.position;
        float len = distance.magnitude;

        float speedx = Mathf.Abs(rigidbody.velocity.x);
        float speedy = Mathf.Abs(rigidbody.velocity.y);
        float speedz = Mathf.Abs(rigidbody.velocity.z);

        if(hitFlag == false)
        {
            if (speedx <= maxspeed || speedy <= maxspeed || speedz <= maxspeed)
            {
                rigidbody.AddForce(ParentTransform.forward * spead * Time.deltaTime, ForceMode.Force);
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