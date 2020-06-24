using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
using MFlight.Demo;

public class LockSend : NetworkBehaviour
{
    public Transform firePoint;
    public GameObject lockTextBox;

    public float LockTime;
    bool FireSuccessful;
    float lockAcummulator;
    public bool haveLock;
    float lastFireSuccess = 0f;
    public PlaneController plane;
    public GameObject target;
    public float minimumDistance;

    void Fire()
    {
        RaycastHit hit;
        Ray rayCast = new Ray(firePoint.position, firePoint.transform.forward);

        if (Physics.Raycast(rayCast, out hit))
        {
            if (hit.collider.tag == "LockReceiver")
            {

                if (hit.distance < minimumDistance)
                {
                    return;
                }

                hit.collider.gameObject.GetComponent<LockHitReceiver>().Hit();
                if (hasAuthority)
                {
                    lastFireSuccess = Time.time;
                    //fuck, that's a lot of abstraction
                    target = hit.collider.gameObject.GetComponent<LockHitReceiver>().parent;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (plane.inspectorAuthority == true)
        {
            lockTextBox.SetActive(true);
        }
        else
        {
            lockTextBox.SetActive(false);
        }

        Fire();
        if (lastFireSuccess + 0.1f > Time.time)
        {
            FireSuccessful = true;
        } else
        {
            FireSuccessful = false;
        }
        if (hasAuthority == false)
        {
            return;
        }
        if (FireSuccessful == true)
        {
            lockAcummulator = lockAcummulator + Time.deltaTime;
            lockTextBox.GetComponent<Text>().text = "ACQUIRING TARGET LOCK";
        } else
        {
            lockAcummulator = 0f;
            lockTextBox.GetComponent<Text>().text = "NO TARGET LOCK";
            haveLock = false;
        }

        if (lockAcummulator > LockTime)
        {
            haveLock = true;
            lockTextBox.GetComponent<Text>().text = "LOCK ESTABLISHED. READY TO FIRE.";
        }
    }
}
