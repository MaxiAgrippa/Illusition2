using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReboundProjectiles : MonoBehaviour
{
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
        if (other.gameObject.tag == "Projectiles")
        {
            other.gameObject.GetComponent<Rigidbody>().velocity = -other.gameObject.GetComponent<Rigidbody>().velocity;
        }
        
    }
}
