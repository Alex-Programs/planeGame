using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public Light spotLight;
    public Transform firePoint;
    public void Start()
    {
        spotLight.type = LightType.Spot;
    }

    public void Update()
    {
        float distance = GetDistance();
        //spotLight.spotAngle = 
    }

    float GetDistance()
    {
        //what does this do? No fucking idea
        RaycastHit hit;
        Ray rayCast = new Ray(firePoint.position, firePoint.transform.forward);
        
        if (Physics.Raycast(rayCast, out hit))
            {
            return hit.distance;
        } else
        {
            return 0;
        }
    }
}
