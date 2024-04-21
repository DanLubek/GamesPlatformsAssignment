using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubeColourChange : MonoBehaviour
{
    static int lightsLookedAt = 0;


    public Material colour1, colour2;

    public UnityEvent LookedAtCubeEvent;

    MeshRenderer cubeMR;

    public Light myLight;

    private void Start()
    {
        cubeMR = GetComponent<MeshRenderer>();

        myLight = GetComponentInChildren<Light>();
    }

    public void ChangeColour()
    {
        if (cubeMR != null)
        { 
            if (cubeMR.sharedMaterial == colour1)
            {
                cubeMR.sharedMaterial = colour2;
                myLight.color = Color.green;
                lightsLookedAt++;
            }
        }
    }

    private void Update()
    {
        if (lightsLookedAt == 3)
        {
            // do stuff
        }
    }
}
