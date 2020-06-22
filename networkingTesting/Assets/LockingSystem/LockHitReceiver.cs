using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using MFlight.Demo;

public class LockHitReceiver : NetworkBehaviour
{
    public PlaneController controller;
    float lastLockTime;
    public float delayBeforeEndLock;
    public GameObject lockedText;
    public GameObject parent;

    bool checkAuthority()
    {
        return controller.inspectorAuthority;
    }
    public void Hit()
    {
        if (checkAuthority())
        {
            lastLockTime = Time.time;
        }
    }

    public void Update()
    {
        if (lastLockTime + delayBeforeEndLock > Time.time)
        {
            lockedText.SetActive(true);
        } else
        {
            lockedText.SetActive(false);
        }
    }
}
