using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class GlideLocomotion : LocomotionProvider
{
    public UnityEvent MovementEvent;
    private bool isMoving;
    public Transform trackedTransform;
    public Transform rigRoot;
    public float velocity = 2f;

    public void PlayerMove()
    {
        if (!isMoving && !CanBeginLocomotion())
        {
            return;
        }

        float forward = Input.GetAxis("XRI_Right_Primary2DAxis_Vertical");
        float sideways = Input.GetAxis("XRI_Right_Primary2DAxis_Horizontal");

        if (forward == 0 && sideways == 0)
        {
            isMoving = false;
            EndLocomotion();
            return;
        }

        if (!isMoving)
        {
            isMoving = true;
            BeginLocomotion();
        }

        if (forward > 0.5f || forward < -0.5f)
        {
            Vector3 moveDirection = Vector3.forward;

            if (trackedTransform != null)
            {
                moveDirection = trackedTransform.forward;
                moveDirection.y = 0f;
            }

            moveDirection *= -forward * velocity * Time.deltaTime;
            rigRoot.Translate(moveDirection);
        }

        //if (trackedTransform == null && sideways != 0f)
        //{
        //    float rotation = sideways * 10 * Time.deltaTime;
        //    rigRoot.Rotate(0, rotation, 0);
        //}
    }
}
