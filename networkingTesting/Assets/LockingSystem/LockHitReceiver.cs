using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using MFlight.Demo;

public class LockHitReceiver : NetworkBehaviour
{
    public PlaneController controller;
    bool isTargetLocked;
    float lastLockTime;
    public float delayBeforeEndLock;
    public GameObject lockedText;

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
            isTargetLocked = true;
        } else
        {
            isTargetLocked = false;
        }

        if (isTargetLocked)
        {
            lockedText.SetActive(true);
        } else
        {
            lockedText.SetActive(false);
        }
    }
}
