using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandChanger : MonoBehaviour
{
    public GameObject rayHand, directHand;

    void DirectHandSwap()
    {
        if (directHand.activeSelf)
        {
            return;
        }
        else
        {
            rayHand.SetActive(false);
            directHand.SetActive(true);
        }       
    }

    void RayHandSwap()
    {
        if (rayHand.activeSelf)
        {
            return;
        }
        else
        {
            rayHand.SetActive(true);
            directHand.SetActive(false);
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DirectInteractable"))
        {
            DirectHandSwap();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("DirectInteractable"))
        {
            RayHandSwap();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, 0.5f);
    }
}
