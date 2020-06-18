using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Mirror.Examples.Basic;

public class PlayerConnectionObject : NetworkBehaviour
{
    public GameObject playerUnitPrefab;

    public void Start()
    {
        if (isLocalPlayer == false)
        {
            return;
        }
        Debug.Log("PlayerConnectionObject::Start -- Spawning my own personal player unit");
        //Instantiate(PlayerUnitPrefab)

        //command the server to spawn our unit
        CmdSpawnMyUnit();

    }

    //called from the plane just before it dies.

    [Command]
    public void CmdSpawnMyUnit()
    {
        //running on the server
        GameObject go = Instantiate(playerUnitPrefab);

        //now it exists serverside, propagate over network to all clients

        //spawn
        NetworkServer.Spawn(go);
        Debug.Log("Spawned");
        //assign client authority
        go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
        Debug.Log("Assigned connection to client");
    }

}
