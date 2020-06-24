using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float speed;
    public Transform place1;
    public Transform place2;
    public Transform place3;
    public Transform place4;

    float rotation;
    int placeIndex = 0;

    public void Start()
    {
        ChangeScene();
    }

    void ChangeScene()
    {
        Debug.Log("Changing scene");
        rotation = 0;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 0, transform.eulerAngles.z);

        placeIndex = placeIndex + 1;
        if (placeIndex > 4)
        {
            placeIndex = 1;
        }

        if (placeIndex == 1)
        {
            transform.position = place1.transform.position;

        } else if (placeIndex == 2)
        {
            transform.position = place2.transform.position;
        } else if (placeIndex == 3)
        {
            transform.position = place3.transform.position;
        } else if (placeIndex == 4)
        {
            transform.position = place4.transform.position;
        }
    }
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
        rotation = rotation + (speed * Time.deltaTime);

        if (rotation > 480)
        {
            ChangeScene();
        }
    }
}
