using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessFromVolume : MonoBehaviour
{
    // this object's rigidbody
    public Rigidbody rigidbody;
    // this object's mass
    public float mass;

    /// <summary>
    /// When the object is enabled
    /// </summary>
    void OnEnable()
    {
        // use VolumeOfMesh(), to calculate the volume of the object and take that as the mass. 
        mass = Universe.VolumeOfMesh(this.GetComponent<MeshFilter>().mesh, transform.localScale) * 100;
        // set this rigidbody's mass to mass we calculated
        rigidbody.mass = mass;
    }
}
