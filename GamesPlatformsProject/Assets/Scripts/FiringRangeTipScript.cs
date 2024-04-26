using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringRangeTipScript : MonoBehaviour
{
    public PlayerControlManager pcm;

    bool hasEntered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasEntered)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                hasEntered = true;
                pcm.DisplayNextTip(4);
                gameObject.SetActive(false);
            }
        }
    }
}
