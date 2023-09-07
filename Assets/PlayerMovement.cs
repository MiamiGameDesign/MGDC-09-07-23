using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 v = GetComponent<Rigidbody>().velocity;
        v.x = Input.GetAxis("Horizontal");
        v.x *= -5;
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
