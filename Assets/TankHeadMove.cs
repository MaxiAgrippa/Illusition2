using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankHeadMove : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // NOTE: those move is according to the local transform direction, the camera is rotated. 
        // press F to turn left
        if (Input.GetKey(KeyCode.F))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * 10);
        }
        // press H to turn right
        else if (Input.GetKey(KeyCode.H))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 10);
        }
    }
}
