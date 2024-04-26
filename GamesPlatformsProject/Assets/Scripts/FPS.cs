using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour
{
    private float fps;
    public TMPro.TMP_Text fpsText;

    void Start()
    {
        InvokeRepeating("DisplayFramerate", 1, 1);
    }

    void DisplayFramerate()
    {
        fps = (int)(1f / Time.unscaledDeltaTime);
        fpsText.text = "FPS : " + fps.ToString();
    }
}
