using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    protected int score = 0;

    protected bool isShootingTargets = false;

    float t = 0;
    

    void Update()
    {
        if (isShootingTargets)
        {
            t += Time.deltaTime;
            if (t <= 30)
            {
                isShootingTargets = false;
            }
        }        
    }

    public void StartGame()
    {
        isShootingTargets = true;
    }
}
