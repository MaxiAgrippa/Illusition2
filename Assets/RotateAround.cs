using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject rotateAroundTarget;
    public Vector3 rotateAroundTargetAxis = new Vector3(0, 1, 0);
    public float rotateAngle = 0.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.RotateAround(rotateAroundTarget.transform.position, rotateAroundTargetAxis, rotateAngle);
    }
}
