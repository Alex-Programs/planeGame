using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedPlanePrefabScript : MonoBehaviour
{
    Vector3 startLoc;
    // Start is called before the first frame update
    void Start()
    {
        startLoc = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(startLoc, transform.position);
        if (distance > 20000)
        {
            Destroy(gameObject);
        }
    }
}
