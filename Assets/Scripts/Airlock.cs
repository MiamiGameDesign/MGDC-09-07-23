using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Airlock : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Airlock"))
        {
            transform.position = Vector3.MoveTowards(transform.position, collision.gameObject.transform.position, 0.1f);
        }
    }
}
