using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public float delay = 1;
    public int speed;
    private float nextPlane;
    public GameObject prefab;
    public GameObject prefabWithHitbox;
    bool doDelay = true;

    public void Start()
    {
        nextPlane = Time.time + delay;
    }
    void Update()
    {
        if (doDelay == true)
        {
            if (Time.time > nextPlane)
            {
                GameObject go = Instantiate(prefab, transform.position, Quaternion.identity);
                Rigidbody rb = go.GetComponent<Rigidbody>();

                rb.AddForce(gameObject.transform.forward * speed, ForceMode.Impulse);
                nextPlane = Time.time + delay;
            }
        } else
        {
            GameObject go = Instantiate(prefabWithHitbox, transform.position, Quaternion.identity);
            Rigidbody rb = go.GetComponent<Rigidbody>();

            rb.AddForce(gameObject.transform.forward * speed, ForceMode.Impulse);
        }
    }

    public void ToggleChaosMode()
    {
        if (doDelay == true)
        {
            doDelay = false;
        }
        else
        {
            doDelay = true;
        }
    }
}
