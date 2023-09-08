using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 v = rb.velocity;
        v.x = Input.GetAxis("Horizontal");
        v.y = Input.GetAxis("Vertical");
        v *= 5;
        GetComponent<Rigidbody>().velocity = v;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 100f))
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 10), ForceMode.Impulse);
            }
        }
        
        
        
    }
}
