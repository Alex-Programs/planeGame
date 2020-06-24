using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruct : MonoBehaviour
{
    public float delay;
    float dieTime;
    void Start()
    {
        dieTime = Time.time + delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > dieTime)
        {
            NetworkServer.Destroy(gameObject);
            Destroy(gameObject);
        }
    }
}
