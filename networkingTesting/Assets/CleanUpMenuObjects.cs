using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUpMenuObjects : MonoBehaviour
{
    float removeTime = 0;
    void Awake()
    {
        removeTime = Time.time + 0.1f;
    }

    public void Update()
    {
        if (Time.time > removeTime)
        {
            GameObject[] allObjects = GameObject.FindGameObjectsWithTag("RemoveOnSpawn");

            foreach (GameObject go in allObjects)
            {
                Destroy(go);
            }
        }
    }
}
