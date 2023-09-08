using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject point1;
    public GameObject point2;
    public float speed;

    [SerializeField]
    private float time = 0;
    private bool directionRight = false;

    // Start is called before the first frame update
    void Start()
    {
        point1.SetActive(false);
        point2.SetActive(false);

        transform.position = point1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(point1.transform.position, point2.transform.position, time);

        if(time < 0)
        {
            directionRight = true;
        }
        else if(time > 1) 
        {
            directionRight = false;
        }

        if(directionRight)
        {
            time += speed;
        }
        else if(!directionRight)
        {
            time -= speed;
        }
    }
}
