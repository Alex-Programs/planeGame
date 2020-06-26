using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class bulletManager : NetworkBehaviour
{
    Vector3 startLoc;
    public float shotTime;

    public GameObject createdby;

    public TrailRenderer trail;

    public float BulletID;

    public Light lightB;
    public GameObject lightGOB;
    Color colour;

    public void Start()
    {
        shotTime = Time.time;
        startLoc = transform.position;
        SetColour();
    }

    public void SetColour()
    {
        colour = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        lightB.color = colour;
        trail.startColor = colour;
        trail.startWidth = Random.Range(0, 1);
        trail.endWidth = Random.Range(2.5f, 6f);
    }

    public void Update()
    {
        float distance = Vector3.Distance(startLoc, transform.position);

        //max distance on the x,y,z axes is 11k. Max diagonal, using a^2 + b+2 = c^2 is 15556. 15556 is the limit!
        if (distance > 15556)
        {
            NetworkServer.Destroy(gameObject);
        }

        if (transform.position.y > 2048)
        {
            lightGOB.SetActive(false);
        } else
        {
            lightGOB.SetActive(true);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            NetworkServer.Destroy(gameObject);
        }
    }
}
