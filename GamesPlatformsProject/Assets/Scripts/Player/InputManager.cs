using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InputManager : MonoBehaviour
{
    public GlideLocomotion glideLoco;

    public XRRayInteractor leftInteractor;

    private void Update()
    {
        glideLoco.MovementEvent.Invoke();

        if (-Input.GetAxis("XRI_Left_Primary2DAxis_Vertical") > 0.5f)
        {
            leftInteractor.enabled = true;
        }
        else
        {
            leftInteractor.enabled = false;
        }
    }
}
