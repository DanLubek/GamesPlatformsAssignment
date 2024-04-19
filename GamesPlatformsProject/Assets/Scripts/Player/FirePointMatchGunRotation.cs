using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointMatchGunRotation : MonoBehaviour
{
    public GameObject gun;

    void Update()
    {
        transform.rotation = gun.transform.rotation;
    }
}
