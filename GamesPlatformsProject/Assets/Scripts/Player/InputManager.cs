using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject gun;

    public GameObject inventory;

    public PlayerController playerController;
    public GlideLocomotion glideLoco;

    private void Update()
    {
        //playerController.MovementEvent.Invoke();
        //playerController.RotationEvent.Invoke();

        glideLoco.MovementEvent.Invoke();

        if (Input.GetKeyDown(KeyCode.K))
        {
            gun.GetComponent<Gun>().grabbed.Invoke();
        }

        if (gun.transform.parent == inventory.transform)
        {
            if (Input.GetKeyDown(KeyCode.N) || Input.GetButtonDown("XRI_Right_TriggerButton"))
            {
                Debug.Log("Fired");
                gun.GetComponent<Gun>().firedGun.Invoke();
            }
        }

        
    }
}
