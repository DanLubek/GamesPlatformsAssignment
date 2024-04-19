using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;

    public bool looking;

    CubeColourChange ccc;

    void Start()
    {
        looking = false;
    }

    void Update()
    {
        Ray ray;
        RaycastHit hit;
        GameObject hitObject;

        Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.rotation * Vector3.forward * 100f);

        ray = new Ray(playerCamera.transform.position, playerCamera.transform.rotation * Vector3.forward);

        if (Physics.Raycast(ray, out hit))
        {
            hitObject = hit.collider.gameObject;

            if (hitObject.CompareTag("ColourCube") && !looking)
            {
                looking = true;

                ccc = hitObject.GetComponent<CubeColourChange>();

                ccc.LookedAtCubeEvent.Invoke();
            }
            else if (!hitObject.CompareTag("ColourCube"))
            {
                looking = false;
            }
        }
    }
}
