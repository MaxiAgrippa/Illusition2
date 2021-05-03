using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRandomSpeed : MonoBehaviour
{
    // this object's rigidbody
    public Rigidbody rigidbody;
    // max speed limite
    public float maxSpeed;
    // min speed limite
    public float minSpeed;
    // speed vector we got
    public Vector3 speed;
    
    /// <summary>
    /// When the object is enabled
    /// </summary>
    void OnEnable()
    {
        // create a random direction for the speed vector.
        Vector3 speedDirection = new Vector3(Random.Range(0f, 1f), 0f, Random.Range(0f, 1f));
        // create a random speed value between the limite. 
        speed = speedDirection.normalized * Random.Range(minSpeed, maxSpeed);
        // give the speed to our object. 
        rigidbody.velocity = speed;
    }
}
