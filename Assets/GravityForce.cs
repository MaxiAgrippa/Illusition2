using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForce : MonoBehaviour
{
    // this object's rigidbody
    public Rigidbody rigidbody;
    // store all GravityForce components of all objects. 
    public static List<GravityForce> gravityForcesCollections;

    public void FixedUpdate()
    {
        // for each object(those under gravity effect)
        foreach (GravityForce gravityForce in gravityForcesCollections)
        {
            // if the object is not equal to this object. I mean gravity to it self doesn't make sense. 
            if (gravityForce != this)
            {
                // Add Gravity Force that comes from that object. 
                Attract(gravityForce);
            }
        }
    }

    /// <summary>
    /// When the object is enabled
    /// </summary>
    void OnEnable()
    {
        // check if the gravityForcesCollections is initialized or not.
        if (gravityForcesCollections == null)
        {
            // if not initialized, initialize it. 
            gravityForcesCollections = new List<GravityForce>();
        }
        // add this's GravityForce component to the gravityForcesCollections
        gravityForcesCollections.Add(this);
    }

    /// <summary>
    /// When the object is disabled
    /// </summary>
    private void OnDisable()
    {
        // remove this's GravityForce component from the gravityForcesCollections
        gravityForcesCollections.Remove(this);
    }

    /// <summary>
    /// Add Gravity Force to this object's rigidbody. 
    /// </summary>
    /// <param name="targetToAttract"></param>
    public void Attract(GravityForce targetToAttract)
    {
        // get target's rigidbody
        Rigidbody targetRigidbody = targetToAttract.rigidbody;
        // calculate the distance between two target as Vector
        Vector3 distanceVector = targetRigidbody.position - rigidbody.position;
        // get the length of distanceVector
        float distance = distanceVector.magnitude;
        // duplication tolerance, there gonna be two objects at same position.
        if (distance == 0f)
        {
            return;
        }
        // calculate how big the force is
        float forceMagnitude = (rigidbody.mass * targetRigidbody.mass) / Mathf.Pow(distance, 2);
        // multiply the force direction with force value to get the force Vector. 
        Vector3 force = distanceVector.normalized * forceMagnitude * Universe.GravitationalConstant;
        // NOTE: may change this in the future
        // add the force to the rigidbody. 
        rigidbody.AddForce(force);
    }
}
