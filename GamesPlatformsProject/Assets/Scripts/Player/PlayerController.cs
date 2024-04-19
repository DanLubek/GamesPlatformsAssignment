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

    //public UnityEvent MovementEvent;
    //public UnityEvent RotationEvent;

    //public Transform rigRoot;
    //public float velocity = 2f;
    //public float rotationSpeed = 100f;

    //public Transform trackedTransform;

    //bool canTurn;
    //float t = 0;

    //bool isMoving = false;

    void Start()
    {
        looking = false;
        //canTurn = true;

        //if (!rigRoot)
        //{
        //    rigRoot = transform;
        //}
    }

    void Update()
    {
        //t += Time.deltaTime;

        //if (t > 0.25f && !canTurn)
        //{
        //    canTurn = true;
        //    t = 0;
        //}

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

//    public void GlideLocomotion()
//    {
//        float forward = Input.GetAxis("XRI_Right_Primary2DAxis_Vertical");

//#if UNITY_EDITOR
//        forward = -Input.GetAxis("Vertical");
//#endif
//        if (forward == 0)
//        {
//            return;
//        }
//        else if (forward != 0)
//        {
//            Vector3 moveDirection = Vector3.forward;

//            if (trackedTransform != null)
//            {
//                moveDirection = trackedTransform.forward;
//                moveDirection.y = 0f;
//            }

//            moveDirection *= -forward * velocity * Time.deltaTime;
//            rigRoot.Translate(moveDirection);
//        }
//    }

//    public void RotatePlayer()
//    {
//        if (canTurn)
//        {
//            float sideways = Input.GetAxis("XRI_Right_Primary2DAxis_Horizontal");

//            float rotation = 0;

//#if UNITY_EDITOR
//            sideways = Input.GetAxis("Horizontal");
//#endif

//            if (sideways == 0)
//            {
//                return;
//            }
//            else if (sideways != 0f)
//            {
//                if (sideways > 0.3f)
//                {
//                    rotation = 45;
//                }
//                else if (sideways < -0.3f)
//                {
//                    rotation = -45;
//                }
//            }

//            rigRoot.Rotate(0, rotation, 0);

//            canTurn = false;
//        }
//        else
//        {
//            return;
//        }
        
//    }
}
