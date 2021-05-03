using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveIn2D : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // NOTE: those move is according to the local transform direction, the camera is rotated. 
        // press W to move up
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * 10);
        }
        // press S to move down
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * 10);
        }
        // press A to move left
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 10);
        }
        // press D to move right
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 10);
        }
        // scroll mouse scroll to move far or close
        transform.Translate(0, 0, Input.mouseScrollDelta.y * 3);


    }
}
