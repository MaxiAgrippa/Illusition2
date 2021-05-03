using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    public float selfXRotateSpeed = 0.5f;
    public float selfYRotateSpeed = 0.4f;
    public float selfZRotateSpeed = 0.6f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(1 * selfXRotateSpeed, 1 * selfYRotateSpeed, 1 * selfZRotateSpeed);
    }
}
