using MFlight;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    public GameObject controller;
    void Update()
    {
        if (controller.GetComponent<MouseFlightController>().externallySetHasAuthority == false)
        {
            gameObject.GetComponent<Camera>().enabled = false;
            Debug.Log("Disabling camera");
        } else
        {
            gameObject.GetComponent<Camera>().enabled = true;
            Debug.Log("Enabling camera");
        }
    }
}
