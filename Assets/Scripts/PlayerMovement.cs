using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
<<<<<<< HEAD

    public float speed = 5f;
=======
    public Rigidbody rb;
>>>>>>> 4c0450fee3b4b017f9a9f0075ab4ae818c99a98d

    void Start()
    {
        
    }

    void Update()
    {
<<<<<<< HEAD
        Vector3 v = GetComponent<Rigidbody>().velocity;
        v.x = Input.GetAxis("Horizontal");
        v.x *= -speed;
        v.y = Input.GetAxis("Vertical");
        v.y *= speed;
=======
        Vector3 v = rb.velocity;
        v.x = Input.GetAxis("Horizontal");
        v.y = Input.GetAxis("Vertical");
        v *= 5;
>>>>>>> 4c0450fee3b4b017f9a9f0075ab4ae818c99a98d
        GetComponent<Rigidbody>().velocity = v;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
<<<<<<< HEAD
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
=======
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 100f))
>>>>>>> 4c0450fee3b4b017f9a9f0075ab4ae818c99a98d
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 10), ForceMode.Impulse);
            }
        }
<<<<<<< HEAD


    }
    

=======
        
        
        
    }
>>>>>>> 4c0450fee3b4b017f9a9f0075ab4ae818c99a98d
}
