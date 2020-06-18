using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletProp : MonoBehaviour
{
    Vector3 startLoc;

    public TrailRenderer trail;

    public void Start()
    {
        startLoc = transform.position;
        SetColour();
    }

    public void SetColour()
    {
        trail.startColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        trail.startWidth = Random.Range(0, 1);
        trail.endWidth = Random.Range(2.5f, 6f);
    }

    public void Update()
    {
        float distance = Vector3.Distance(startLoc, transform.position);
        if (distance > 6000)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
