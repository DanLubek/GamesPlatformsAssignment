using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTargetManager : MonoBehaviour
{
    private void Start()
    {
        gameObject.AddComponent<TargetManager>();
    }

    public void AddTargetManagerToButton()
    {
        if (!gameObject.GetComponent<TargetManager>())
        {
            gameObject.AddComponent<TargetManager>();
        }

        return;
    }

    public void ButtonPressed()
    {
        if (gameObject.GetComponent<TargetManager>().isShootingTargets)
        {
            return;
        }

        StartCoroutine(SmallDelay());        
    }

    IEnumerator SmallDelay()
    {
        yield return new WaitForSeconds(0.5f);

        gameObject.GetComponent<TargetManager>().enabled = true;

        gameObject.GetComponent<TargetManager>().StartGame();
    }
}
