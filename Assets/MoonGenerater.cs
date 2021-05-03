using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonGenerater : MonoBehaviour
{
    public GameObject originalMoon = null;
    public int numberOfMoon = 10;
    public float maxRadius = 10f;
    public float minRadius = 10f;
    private ArrayList Moons = new ArrayList();
    public bool clockwise = true;
    public float randomDishSurfaceNoiseRange = 0.5f;
    // Rotate Around
    public GameObject rotateAroundTarget = null;
    public Vector3 rotateAroundTargetAxis = new Vector3(0, 1, 0);
    public float rotateAngle = 0.1f;
    // Self Rotate
    public float selfXRotateSpeed = 0.5f;
    public float selfYRotateSpeed = 0.4f;
    public float selfZRotateSpeed = 0.6f;
    // Color Shift
    public Color colorStart = Color.black;
    public Color colorEnd = Color.white;
    float duration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (numberOfMoon <= 0)
        {
            print("numberOfMoon <= 0");
            throw new UnityException();
        }
        if (originalMoon == null)
        {
            print("originalMoon == null");
            throw new UnityException();
        }
        if (rotateAroundTarget == null)
        {
            print("rotateAroundTarget == null");
            throw new UnityException();
        }
        if(randomDishSurfaceNoiseRange < 0)
        {
            print("randomDishSurfaceNoiseRange < 0");
            throw new UnityException();
        }
        if (maxRadius >= minRadius && minRadius >= 0)
        {
            float angleInterval = 360f / numberOfMoon;
            float angleAccumulation = 0;
            for (int i = 0; i < numberOfMoon; i++)
            {
                float randomDishSurfaceNoise = Random.Range(-randomDishSurfaceNoiseRange, randomDishSurfaceNoiseRange);
                GameObject gameObject = GameObject.Instantiate(originalMoon);
                float radius = Random.Range(minRadius, maxRadius);
                gameObject.transform.position = (new Vector3(radius, randomDishSurfaceNoise, 0f));
                gameObject.transform.RotateAround(this.rotateAroundTarget.transform.position, new Vector3(0, 1, 0), (angleAccumulation += angleInterval));

                // Set Rotate Around
                gameObject.GetComponent<RotateAround>().rotateAroundTarget = this.rotateAroundTarget;
                gameObject.GetComponent<RotateAround>().rotateAroundTargetAxis = this.rotateAroundTargetAxis;
                gameObject.GetComponent<RotateAround>().rotateAngle = this.rotateAngle;

                // Set Self Rotate
                gameObject.GetComponentInChildren<SelfRotate>().selfXRotateSpeed = this.selfXRotateSpeed;
                gameObject.GetComponentInChildren<SelfRotate>().selfYRotateSpeed = this.selfYRotateSpeed;
                gameObject.GetComponentInChildren<SelfRotate>().selfZRotateSpeed = this.selfZRotateSpeed;

                // Set Color Shift
                gameObject.GetComponentInChildren<ColorShift>().colorStart = this.colorStart;
                gameObject.GetComponentInChildren<ColorShift>().colorEnd = this.colorEnd;
                gameObject.GetComponentInChildren<ColorShift>().duration = this.duration;


                gameObject.transform.parent = this.transform;

                Moons.Add(gameObject);
            }
        }
        else
        {
            print("minRadius < 0");
            throw new UnityException();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject gameObject in Moons)
        {
            // Set Rotate Around
            gameObject.GetComponent<RotateAround>().rotateAroundTarget = this.rotateAroundTarget;
            gameObject.GetComponent<RotateAround>().rotateAroundTargetAxis = this.rotateAroundTargetAxis;
            gameObject.GetComponent<RotateAround>().rotateAngle = this.rotateAngle;

            // Set SelfRotate
            gameObject.GetComponentInChildren<SelfRotate>().selfXRotateSpeed = this.selfXRotateSpeed;
            gameObject.GetComponentInChildren<SelfRotate>().selfYRotateSpeed = this.selfYRotateSpeed;
            gameObject.GetComponentInChildren<SelfRotate>().selfZRotateSpeed = this.selfZRotateSpeed;
        }
    }
}
