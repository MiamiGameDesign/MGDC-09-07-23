using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Airlock : MonoBehaviour
{
    public AudioSource a;
    public AudioClip airlock;
    public AudioClip gameOver;
    public Text t;
    public LayerMask l;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Airlock"))
        {
            transform.position = Vector3.MoveTowards(transform.position, collision.gameObject.transform.position, 0.025f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Airlock"))
        {
            a.PlayOneShot(airlock, 6);
            a.PlayOneShot(gameOver);
        }
    }
}
