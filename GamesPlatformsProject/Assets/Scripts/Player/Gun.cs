using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public GameObject firePoint;   
    
    public UnityEvent firedGun;
    public UnityEvent grabbed;

    public GameObject player;

    public GameObject projectileObj;

    public GameObject hand;

    public void FireGun()
    {
        Vector3 fpPos = firePoint.transform.position;
        Quaternion fpRot = firePoint.transform.rotation;

        Instantiate(projectileObj, fpPos, fpRot);
    }

    public void Grabbed()
    {
        transform.parent = player.transform.GetChild(0);
        hand.gameObject.SetActive(false);

    }
}
