using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Security.Cryptography;
using Mirror.Examples.Basic;
using MFlight.Demo;
using Mirror.RemoteCalls;

public class PlaneDeath : NetworkBehaviour
{
    bool DoDieNextFrame = false;
    public bool externalAuthority;
    public GameObject controller;
    public TrailRenderer trail;
    public TrailRenderer trail2;
    bool doReenableTrailsNextFrame = false;

    Quaternion startRotation;

    public GameObject deathMessage;

    float closeDeathMessageTime = 0;

    public float deathMessageShowTime;

    GameObject[] missiles;

    public GameObject explosionPrefab;

    public void Start()
    {
        startRotation = this.transform.rotation;
        deathMessage.SetActive(false);
    }

    public void Die()
    {
        CmdCreateExplosion(transform);

        if (hasAuthority == false)
        {
            Debug.Log("Not dying because I don't have authority");
            return;
        }

        GameObject explosion = Instantiate(explosionPrefab, transform);
        explosion.transform.SetParent(null);

        DoDieNextFrame = false;
        Debug.Log("Dying");

        transform.position = new Vector3(0, 600, 0);
        transform.rotation = startRotation;

        this.GetComponent<PlaneController>().thrust = this.GetComponent<PlaneController>().startingThrust;

        doReenableTrailsNextFrame = true;

        deathMessage.SetActive(true);
        closeDeathMessageTime = Time.time + deathMessageShowTime;
    }

    [Command]
    void CmdCreateExplosion(Transform pos)
    {
        GameObject go = Instantiate(explosionPrefab, pos.position, pos.rotation);
        NetworkServer.Spawn(go);
        go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
    }

    public void Update()
    {
        if (Time.time > closeDeathMessageTime)
        {
            deathMessage.SetActive(false);
        }
        externalAuthority = hasAuthority;

        if (DoDieNextFrame)
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            DoDieNextFrame = true;
        }

        if (doReenableTrailsNextFrame)
        {
            trail.emitting = true;
            trail2.emitting = true;
            doReenableTrailsNextFrame = false;
        }

        if (transform.position.x > 12000 | transform.position.x < -12000 | transform.position.y < 0 | transform.position.y > 12000 | transform.position.z < -12000 | transform.position.z > 12000)
        {
            Die();
        }
        CmdCheckForMissiles();
    }

    [Command]
    void CmdCheckForMissiles()
    {
        missiles = GameObject.FindGameObjectsWithTag("Missile");
        foreach (GameObject i in missiles)
        {
            if (Vector3.Distance(i.transform.position, gameObject.transform.position) < 200f)
            {
                NetworkServer.Destroy(i);
                Destroy(i);
                RpcDie();
            }
        }
    }

    [ClientRpc]
    void RpcDie()
    {
        Die();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet" | other.gameObject.tag == "Terrain" | other.gameObject.tag == "Player")
        {
            Debug.Log("# Dying - plane");
            DoDieNextFrame = true;
            trail.emitting = false;
            trail2.emitting = false;
        }
    }
}
