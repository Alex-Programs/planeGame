using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LockSend : NetworkBehaviour
{
    public Transform firePoint;
    float nextLockPulse;
    public float pulseDelay;
    public GameObject lockSuccesful;
    bool haveLock;
    float lastLockTime;

    public void Start()
    {
        lockSuccesful.SetActive(false);
    }
    void Fire()
    {
        RaycastHit hit;
        Ray rayCast = new Ray(firePoint.position, firePoint.transform.forward);

        if (Physics.Raycast(rayCast, out hit))
        {
            if (hit.collider.tag == "LockReceiver")
            {
                hit.collider.gameObject.GetComponent<LockHitReceiver>().Hit();
                if (hasAuthority)
                {
                    lastLockTime = Time.time;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextLockPulse)
        {
            nextLockPulse = Time.time + pulseDelay;
            Fire();
        }

        if (Time.time > lastLockTime + pulseDelay + 0.1f)
        {
            haveLock = false;
        } else
        {
            haveLock = true;
        }
        
        if (haveLock == true)
        {
            lockSuccesful.SetActive(true);
        } else
        {
            lockSuccesful.SetActive(false);
        }
    }
}
