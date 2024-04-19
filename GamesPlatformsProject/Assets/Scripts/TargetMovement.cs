using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private static int score;

    //private Vector3 upPos = new Vector3(45.5f, 0.04f, 8.65f);
    //private Vector3 downPos = new Vector3(43.9f, -1.04f, -6.78f);

    private Transform target;
    bool isMoving;
    bool isDown;

    void Start()
    {
        target = gameObject.transform;

        //target.position = upPos;

        score = 0;
        isMoving = false;
        isDown = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TargetHit();
        }

        //if (target.position == downPos && isMoving)
        //{
        //    isDown = true;
        //    isMoving = false;

        //    StartCoroutine(ResetPos());
        //}

        //if (target.position == upPos)
        //{
        //    isMoving = false;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            TargetHit();
        }
    }

    private void TargetHit()
    {
        isMoving = true;
        score++;        

        target.Translate(new Vector3(target.position.x, target.position.y - 1f, target.position.z) * 2f * Time.deltaTime);
        // CONVERT TO LERP?

        //if (target.position == downPos)
        //{
        //    StartCoroutine(ResetPos());
        //}

        StartCoroutine(ResetPos());
    }

    IEnumerator ResetPos()
    {
        yield return new WaitForSeconds(2f);

        target.Translate(new Vector3(target.position.x, target.position.y + 1f, target.position.z) * 2f * Time.deltaTime);
    }
}
