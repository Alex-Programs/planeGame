using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityMarker : MonoBehaviour
{
    public Transform a;
    public Transform b;
    public Transform c;
    public Transform d;
    public Transform e;
    public Transform f;

    void Update()
    {
        if (QualitySettings.GetQualityLevel() == 0)
        {
            transform.position = a.position;
        } else if (QualitySettings.GetQualityLevel() == 1)
        {
            transform.position = b.position;
        }
        else if (QualitySettings.GetQualityLevel() == 2)
        {
            transform.position = c.position;
        }
        else if (QualitySettings.GetQualityLevel() == 3)
        {
            transform.position = d.position;
        }
        else if (QualitySettings.GetQualityLevel() == 4)
        {
            transform.position = e.position;
        }
        else if (QualitySettings.GetQualityLevel() == 5)
        {
            transform.position = f.position;
        }
    }
}
