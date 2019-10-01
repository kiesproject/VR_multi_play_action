using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public int hitcount = 0;

public class PlayerScript : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
        hitcount += 1;
    }

}
