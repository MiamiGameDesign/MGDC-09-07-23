using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirlockSound : MonoBehaviour
{
    public AudioSource a;
    public AudioClip airlock;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            a.PlayOneShot(airlock, 6);
            Debug.Log(collision.name);
        }
    }
}
