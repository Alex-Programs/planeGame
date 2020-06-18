using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinButton : MonoBehaviour
{
    private Text text;
    void Awake()
    {
        text = GetComponentInChildren<Text>();
    }

    public void Initialize()
    {
        
    }
}
