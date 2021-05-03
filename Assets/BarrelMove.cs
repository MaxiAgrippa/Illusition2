using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelMove : MonoBehaviour
{
    public float minRotation = 75;
    public float maxRotation = 105;
    // Update is called once per frame
    private void FixedUpdate()
    {
        // NOTE: those move is according to the local transform direction, the camera is rotated. 
        // press T to move up
        if (Input.GetKey(KeyCode.T))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * 10);
        }
        // press G to move down
        else if (Input.GetKey(KeyCode.G))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * 10);
        }

        Vector3 currentRotation = transform.localRotation.eulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, minRotation, maxRotation);
        transform.localRotation = Quaternion.Euler(currentRotation);
    }
}
