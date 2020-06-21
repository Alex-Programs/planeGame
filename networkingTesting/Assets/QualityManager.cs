using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityManager : MonoBehaviour
{
    public void VeryLow()
    {
        QualitySettings.SetQualityLevel(0, true);
        Debug.Log("Very low");
    }

    public void Low()
    {
        QualitySettings.SetQualityLevel(1, true);
        Debug.Log("Low");
    }

    public void Medium()
    {
        QualitySettings.SetQualityLevel(2, true);
        Debug.Log("Medium");
    }

    public void High()
    {
        QualitySettings.SetQualityLevel(3, true);
        Debug.Log("High");
    }

    public void VeryHigh()
    {
        QualitySettings.SetQualityLevel(4, true);
        Debug.Log("Very high");
    }

    public void Ultra()
    {
        QualitySettings.SetQualityLevel(5, true);
        Debug.Log("Ultra");
    }
}
