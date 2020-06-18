using Mirror;
using Mirror.Websocket;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomNetworkManager : NetworkManager
{
    public InputField ipBox;

    public GameObject disconnectBox;

    public GameObject dedicatedServerBox;

    public static string serverIP;

    public override void Awake()
    {
        disconnectBox.SetActive(false);
        base.Awake();
    }

    public void StartHosting()
    {
        serverIP = "deleteThis";
        base.StartHost();
    }

    public void JoinMatch()
    {
        base.networkAddress = ipBox.text; //"192.168.1.91"; //new Uri(ipBox.text.ToString(), UriKind.RelativeOrAbsolute);
        serverIP = ipBox.text;
        Debug.Log(base.networkAddress);

        base.StartClient();
    }

    public void RunDedicatedServer()
    {
        base.StartServer();
        disconnectBox.SetActive(true);
        dedicatedServerBox.SetActive(false);
    }

    public void DisconnectDedicatedServer()
    {
        base.StopServer();
        disconnectBox.SetActive(false);
        dedicatedServerBox.SetActive(true);
    }
}