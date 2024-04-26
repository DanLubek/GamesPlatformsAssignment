using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public GameObject firePoint;

    public GameObject player;

    public GameObject projectileObj;

    public GameObject hand;

    public Collider col1, col2;

    Vector3 fpPos;
    Quaternion fpRot;

    public ParticleSystem muzzleFlash;

    public void FireGun()
    {
        fpPos = firePoint.transform.position;
        fpRot = firePoint.transform.rotation;

        Instantiate(projectileObj, fpPos, fpRot);
        muzzleFlash.Play();
    }

    public void Grabbed()
    {
        hand.gameObject.SetActive(false);
        transform.parent = player.transform.GetChild(0);
    }

    public void Released()
    {        
        transform.parent = null;
        Physics.IgnoreCollision(col1, hand.gameObject.GetComponent<Collider>(), true);
        Physics.IgnoreCollision(col2, hand.gameObject.GetComponent<Collider>(), true);
        hand.gameObject.SetActive(true);
        StartCoroutine(ReEnableHandCollision());
    }

    IEnumerator ReEnableHandCollision()
    {
        yield return new WaitForSeconds(0.5f);

        Physics.IgnoreCollision(col1, hand.gameObject.GetComponent<Collider>(), false);
        Physics.IgnoreCollision(col2, hand.gameObject.GetComponent<Collider>(), false);
    }
}
