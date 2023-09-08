using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    public GameObject key;
    public GameObject door;
    public GameObject followKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!key.activeInHierarchy)
        {
            Destroy(door);
            followKey.SetActive(false);
        }
    }
}
