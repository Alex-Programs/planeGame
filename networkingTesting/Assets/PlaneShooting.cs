using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class PlaneShooting : NetworkBehaviour
{
    public Transform firePointOne;
    public Transform firePointTwo;
    public Transform firePointThree;

    public GameObject BulletPrefab;
    public float BulletForce;

    float gunHeat;
    public float gunOverloadLimit;
    public float gunCoolAmount;

    float nextCoolTime = 0;

    float lastShotTime = 0;

    public float delayBeforeCoolingAllowed = 0.2f;

    public GameObject heatMarker;

    float alpha = 0;

    public float FireRate = 0.1f;

    private float nextFireTime = 0f;

    private float nextCentralFireTime = 0f;

    public float CentralFireRate = 0.05f;

    public float spread;

    public float CentralSpread;

    // Update is called once per frame
    void Update()
    {
        if (hasAuthority == false)
        {
            Debug.Log("No authority in plane shooting, not running");
            return;
        }

        if (Time.time > nextCoolTime && (lastShotTime + delayBeforeCoolingAllowed) < Time.time)
        {
            gunHeat = gunHeat - (gunHeat / gunCoolAmount);
            nextCoolTime = nextCoolTime + 0.1f;
        }

        if (gunHeat < 1)
        {
            gunHeat = 0;
        }

        if (gunHeat > gunOverloadLimit)
        {
            gunHeat = gunOverloadLimit;
        }
        alpha = (gunHeat / gunOverloadLimit) * 255;
        alpha = alpha / 2;

        heatMarker.GetComponent<RawImage>().color = new Color32(255, 0, 0, (byte)alpha);
        heatMarker.GetComponent<Transform>().localScale = new Vector3(alpha / 255, alpha / 255, alpha / 255);

        if (Input.GetMouseButton(0) && Time.time > nextFireTime)
        {
            if (gunHeat < gunOverloadLimit)
            {
                CmdSpawnBullet(firePointOne.transform.position + (firePointOne.transform.forward), firePointOne.transform.rotation, gameObject.GetComponent<Rigidbody>().velocity.magnitude, BulletForce, spread * 1.5f);
                gunHeat = gunHeat + 1;
                lastShotTime = Time.time;
            }
            if (gunHeat < gunOverloadLimit)
            {
                CmdSpawnBullet(firePointTwo.transform.position + (firePointTwo.transform.forward), firePointTwo.transform.rotation, gameObject.GetComponent<Rigidbody>().velocity.magnitude, BulletForce, spread * 1.5f);
                gunHeat = gunHeat + 1;
                lastShotTime = Time.time;
            }


            nextFireTime = Time.time + FireRate;
        }

        if (Input.GetMouseButton(0) && Time.time > nextCentralFireTime)
        {
            if (gunHeat < gunOverloadLimit)
            {
                CmdSpawnBullet(firePointThree.transform.position + (firePointThree.transform.forward), firePointThree.transform.rotation, gameObject.GetComponent<Rigidbody>().velocity.magnitude, BulletForce, CentralSpread * 1.5f);
                nextCentralFireTime = Time.time + CentralFireRate;
                gunHeat = gunHeat + 1;
                lastShotTime = Time.time;
            }
        }

        if (Input.GetMouseButton(1) && Time.time > nextFireTime)
        {
            if (gunHeat < gunOverloadLimit)
            {
                CmdSpawnBullet(firePointOne.transform.position + (firePointOne.transform.forward), firePointOne.transform.rotation, gameObject.GetComponent<Rigidbody>().velocity.magnitude, BulletForce, spread / 2f);
                gunHeat = gunHeat + 1;
                lastShotTime = Time.time;
            }
            if (gunHeat < gunOverloadLimit)
            {
                CmdSpawnBullet(firePointTwo.transform.position + (firePointTwo.transform.forward), firePointTwo.transform.rotation, gameObject.GetComponent<Rigidbody>().velocity.magnitude, BulletForce, spread / 2f);
                gunHeat = gunHeat + 1;
                lastShotTime = Time.time;
            }


            nextFireTime = Time.time + FireRate;
        }

        if (Input.GetMouseButton(1) && Time.time > nextCentralFireTime)
        {
            if (gunHeat < gunOverloadLimit)
            {
                CmdSpawnBullet(firePointThree.transform.position + (firePointThree.transform.forward), firePointThree.transform.rotation, gameObject.GetComponent<Rigidbody>().velocity.magnitude, BulletForce, CentralSpread / 2f);
                nextCentralFireTime = Time.time + CentralFireRate;
                gunHeat = gunHeat + 1;
                lastShotTime = Time.time;
            }
        }
    }

    [Command]
    void CmdSpawnBullet(Vector3 loc, Quaternion direction, float velocity, float force, float spread)
    {
        //running on the server
        GameObject go = Instantiate(BulletPrefab, loc, direction);

        //get rigidbody
        Rigidbody rb = go.GetComponent<Rigidbody>();

        //make them spread using random deviation
        go.transform.rotation = direction;

        float randomX = Random.Range(-spread, spread);
        float randomY = Random.Range(-spread, spread);
        float randomZ = Random.Range(-spread, spread);
        //rotate using the random deviation
        go.transform.Rotate(randomX, randomY, randomZ);
        //calculate impart force
        float impartForce = force + velocity;
        //add force to propel forwards
        rb.AddForce(go.transform.forward * impartForce, ForceMode.Impulse);
        //spawn and propagate to network clients

        NetworkServer.Spawn(go);
        go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
    }
}
