using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public AudioSource audioSource;
    public float hitcount = 0;

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
        hitcount += 1;
    }

}