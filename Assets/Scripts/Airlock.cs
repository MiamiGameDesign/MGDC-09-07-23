using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airlock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Airlock"))
        {
            transform.position = Vector3.MoveTowards(transform.position, collision.gameObject.transform.position, 0.025f);
        }
    }
}
