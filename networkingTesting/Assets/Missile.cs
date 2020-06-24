using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Mirror;

public class Missile : MonoBehaviour
{
    public GameObject target;
    public float explodeRange;
    public float speed;
    Rigidbody rb;

    float lowestDistance;
    GameObject lowestGameObject;
    float dist;
    public float fuel = 100;

    public void Start()
    {
        Debug.Log("Started missile");
        rb = this.GetComponent<Rigidbody>();

        //because fuck referring server side, I guess
        GameObject[] planes;
        planes = GameObject.FindGameObjectsWithTag("Player");

        lowestDistance = 1000000f;
        
        foreach(GameObject obj in planes)
        {
            dist = Vector3.Distance(gameObject.transform.position, obj.transform.position);
            if (dist < lowestDistance)
            {
                lowestDistance = dist;
                lowestGameObject = obj;
            }
        }

        target = lowestGameObject.GetComponent<LockSend>().target;
    }

    void FixedUpdate()
    {
        //this part does the turning
        if (Vector3.Distance(transform.position, target.transform.position) > 500)
        {
            transform.LookAt(target.transform);
        }
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);

        Debug.Log("[]" + target.ToString());
    }

    public void Update()
    {
        fuel = fuel - Time.deltaTime;
        Debug.Log("FUEL: " + fuel.ToString());

        if (fuel < 0f)
        {
            NetworkServer.Destroy(gameObject);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet" | other.gameObject.tag == "Terrain")
        {
            //I can't create an explosion because apparently accessing network functions in a script where I imported them would be to much
            NetworkServer.Destroy(gameObject);
            Destroy(gameObject);
        }
    }
}
