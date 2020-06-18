using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
