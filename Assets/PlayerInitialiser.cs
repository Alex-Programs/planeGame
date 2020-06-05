using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Security.Permissions;

public class PlayerInitialiser : NetworkBehaviour
{
    public GameObject plane;
    public GameObject hud;
    public GameObject flightRig;

    GameObject createdPlaneLocal;

    void Start()
    {
        if (isLocalPlayer == true)
        {
            //we'll get the plane via the rpc call and it'll be set to the createdPlane class var
            CmdCreatePlane();
            Debug.Log("#1");
            GameObject createdHud = Instantiate(hud);
            Debug.Log("#2");
            GameObject createdRig = Instantiate(flightRig);
            Debug.Log("#3");

            UnityEngine.Debug.Log("##");
            if (createdPlaneLocal == null)
            {
                Debug.Log("Yeah, it's null.");
            } else
            {
                Debug.Log("Not null");
            }

            //now setup stuff on them to link it all up. 
            Debug.Log("Setting-1");
            createdPlaneLocal.SendMessage("SetParameters", createdRig);
        }
    }

    [Command]
    void CmdCreatePlane()
    {
        GameObject createdPlane = Instantiate(plane);
        //spawn with client authority
        NetworkServer.Spawn(createdPlane, connectionToClient);

        TargetReturnData(connectionToClient, createdPlane);
    }

    [TargetRpc]
    public void TargetReturnData(NetworkConnection target, GameObject _createdPlane)
    {
        createdPlaneLocal = _createdPlane;
        Debug.Log("Run target");

    }
}
