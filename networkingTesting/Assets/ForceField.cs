using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    GameObject[] players; 

    public void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in players)
        {
            if (go.GetComponent<ForceFieldReply>().QueryAuthority() == true)
            {
                Debug.Log("#Have authority");
                float distance = Vector3.Distance(go.transform.position, transform.position);

                if (distance < 2000)
                {
                    Debug.Log("#Showing");
                    gameObject.GetComponent<Renderer>().enabled = true;
                } else
                {
                    Debug.Log(distance.ToString());
                    gameObject.GetComponent<Renderer>().enabled = false;
                }
                
            }
        }
    }
}
