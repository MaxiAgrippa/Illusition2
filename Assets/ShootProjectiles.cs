using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    // the projectile(a GameObject) we gonna generate and shoot
    public GameObject projectile;

    public float forceParameter = 100;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject shootedProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            shootedProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * forceParameter);
        }
    }
}
