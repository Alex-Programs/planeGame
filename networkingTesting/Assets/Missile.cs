using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public GameObject target;
    public float explodeRange;
    public float speed;
    Rigidbody rb;

    float lowestDistance;
    GameObject lowestGameObject;
    float dist;
    float dieTime = Mathf.Infinity;

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
        transform.LookAt(target.transform);
        rb.AddForce(transform.forward * speed, ForceMode.Impulse);

        Debug.Log("[]" + target.ToString());
    }

    public void Update()
    {
        if (Time.time > dieTime)
        {
            Debug.Log("Dying");
            NetworkServer.Destroy(gameObject);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        dieTime = Time.time + 0.1f;
    }
}
