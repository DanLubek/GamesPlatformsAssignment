using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetMove : TargetManager
{
    public UnityEvent disappearEvent;

    public void Disappear()
    {
        if (isShootingTargets)
        {
            score++;
        }
        
        gameObject.SetActive(false);

        StartCoroutine("ReappearDelay");
    }

    IEnumerator ReappearDelay()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));

        gameObject.SetActive(true);
    }
}
