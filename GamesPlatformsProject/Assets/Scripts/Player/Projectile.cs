using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private void Start()
    {
        //gameObject.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * 50f, ForceMode.Impulse);
        gameObject.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0, 0, 20));
    }

    private void Update()
    {
        //if (gameObject.activeSelf)
        //{
        //    Destroy(gameObject, 5);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (!collision.gameObject.CompareTag("Gun"))
        //{
        //    Destroy(gameObject);
        //}        
    }
}
