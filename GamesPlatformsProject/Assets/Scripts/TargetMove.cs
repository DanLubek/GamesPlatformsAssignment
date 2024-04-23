using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    Vector3 startPos, tempPos;

    private void Start()
    {
        startPos = transform.position;
        tempPos = new Vector3(0, -10, 0);
    }

    public void Disappear(bool respawn)
    {
        transform.position = tempPos;        

        if (respawn)
        {
            TargetManager.score++;
            StartCoroutine(RespawnDelay());
        }
    }

    public void Reappear()
    {
        transform.position = startPos;
    }

    IEnumerator RespawnDelay()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));

        Reappear();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Disappear(true);
        }
    }
}
