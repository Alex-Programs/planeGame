using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confinePointer : MonoBehaviour
{
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
    }
}
