using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuShooting : MonoBehaviour
{
    public GameObject bulletProp;
    float nextFireTime;
    float fireRate = 0.1f;

    public GameObject firePointA;
    public GameObject firePointB;
    public GameObject firePointC;

    public float spread = 3f;

    void Fire(Vector3 Position, Quaternion direction, float force, float spread)
    {
        GameObject go = Instantiate(bulletProp, Position, direction);

        //get rigidbody
        Rigidbody rb = go.GetComponent<Rigidbody>();

        //make them spread using random deviation
        go.transform.rotation = direction;

        float randomX = Random.Range(-spread, spread);
        float randomY = Random.Range(-spread, spread);
        float randomZ = Random.Range(-spread, spread);
        //rotate using the random deviation
        go.transform.Rotate(randomX, randomY, randomZ);
        //calculate impart force
        //add force to propel forwards
        rb.AddForce(go.transform.forward * force, ForceMode.Impulse);

        nextFireTime = Time.time + fireRate;
    }

    public void Update()
    {
        if (Time.time > nextFireTime)
        {
            Fire(firePointA.transform.position + firePointA.transform.forward, firePointA.transform.rotation, 2000f, spread);
            Fire(firePointB.transform.position + firePointB.transform.forward, firePointB.transform.rotation, 2000f, spread);
            Fire(firePointC.transform.position + firePointC.transform.forward, firePointC.transform.rotation, 2000f, spread);
        }
    }
}
