using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubeColourChange : MonoBehaviour
{
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
            }
            else if (cubeMR.sharedMaterial == colour2)
            {
                cubeMR.sharedMaterial = colour1;
                myLight.color = Color.red;
            }
        }
    }
}
