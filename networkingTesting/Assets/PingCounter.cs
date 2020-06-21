using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System;
using MFlight.Demo;

public class PingCounter : MonoBehaviour
{
    public Text self;

    private List<int> _pingTime = new List<int>();

    bool hasStarted = false;

    public string target = null;

    float average;

    public PlaneController planeController;

    public void Start()
    {
        target = CustomNetworkManager.serverIP;
    }
    public void Update()
    {
        if (target == "deleteThis" | planeController.inspectorAuthority == false)
        {
            Destroy(gameObject);
        }
        if (hasStarted == false)
        {
            if (target == null)
            {
                return;
            } else
            {
                StartCoroutine(PingUpdate());
                hasStarted = true;
            }
        }
        average = 0f;

        //iterates through last 10 items in list
        for (int i = Math.Max(_pingTime.Count - 10, 0); i < _pingTime.Count; ++i)
        {
            average = average + i;
        }

        self.text = (average / 10f).ToString();
    }

    IEnumerator PingUpdate()
    {
        while (true)
        {
            Ping ping = new Ping(target);

            //yield return new WaitForSeconds(0.1f);
            while (!ping.isDone) yield return null;

            _pingTime.Add(ping.time);
        }
    }
}
