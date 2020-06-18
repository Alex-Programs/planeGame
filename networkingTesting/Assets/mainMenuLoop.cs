using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class mainMenuLoop : MonoBehaviour
{
    float startTime;
    public float animationLength;
    public float speed;
    Rigidbody rb;
    float nextAnimationTime = 0;

    public TrailRenderer trail1;
    public TrailRenderer trail2;

    bool isNextRunHalfway = false;

    int frameToReenableTrails;

    int FrameCount = 0;

    Vector3 startLoc;

    public void Awake()
    {
        startTime = Time.time;
        rb = gameObject.GetComponent<Rigidbody>();
        startLoc = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    void Update()
    {
        FrameCount = FrameCount + 1;

        if (FrameCount == frameToReenableTrails)
        {
            trail1.time = 5;
            trail2.time = 5;
        }

        if (Time.time > nextAnimationTime)
        {
            if (isNextRunHalfway == true)
            {
                Debug.Log("Halfway animation");
                //turn off early
                trail1.time = 0;
                trail2.time = 0;

                //speed up so it's less boring
                rb.AddForce(gameObject.transform.forward * speed, ForceMode.Impulse);
                isNextRunHalfway = false;
                nextAnimationTime = Time.time + animationLength;
            } else
            {
                Debug.Log("Restarting animation");
                //stop
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                //move
                gameObject.transform.position = startLoc;

                //add force
                rb.AddForce(gameObject.transform.forward * speed, ForceMode.Impulse);

                nextAnimationTime = Time.time + animationLength;

                    //reenable trails
                    frameToReenableTrails = FrameCount + 3;

                isNextRunHalfway = true;
            }
        }
    }
}
