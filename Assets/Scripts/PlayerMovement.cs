using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 v = GetComponent<Rigidbody>().velocity;
        v.x = Input.GetAxis("Horizontal");
        v.x *= -speed;
        v.y = Input.GetAxis("Vertical");
        v.y *= speed;
        GetComponent<Rigidbody>().velocity = v;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 10), ForceMode.Impulse);
            }
        }


    }
    

}
