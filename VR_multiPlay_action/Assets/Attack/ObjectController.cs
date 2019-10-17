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

    bool hitFlag = false;
    [SerializeField] float lifeTime = 5.0f;

    [SerializeField] Vector3 RotateAngle = Vector3.zero;

    [SerializeField] AudioSource ShootAudio;
    [SerializeField] AudioSource fallAudio;

    public bool falling = false;

    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        generator = GameObject.FindGameObjectWithTag("Generator").GetComponent<Generator>();
        rigidbody = GetComponent<Rigidbody>();

        startPos = transform.position;

        if(falling == true)
        {
            fallAudio.Play();
        }
        else
        {
            ShootAudio.Play();
        }

        rigidbody.AddForce(transform.forward * spead, ForceMode.Impulse);
    }

    void Update()
    {
        this.distance = startPos - transform.position;
        float len = distance.magnitude;
       
        if(hitFlag == true)
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime < 0)
            {
                Destroy(this.gameObject);
            }
        }
        else
        {
            rigidbody.AddTorque(RotateAngle * Time.deltaTime);
        }

        if (len >= generator.distance)
        {
            Debug.Log("DESTROY");
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