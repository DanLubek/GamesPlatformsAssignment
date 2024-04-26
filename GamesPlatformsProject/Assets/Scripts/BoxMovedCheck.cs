using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovedCheck : MonoBehaviour
{
    static int numberMoved = 0;

    Vector3 startPos;

    bool hasMoved;

    public PlayerControlManager pcm;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        hasMoved = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasMoved)
        {
            if (Vector3.Distance(startPos, transform.position) > 2f)
            {
                hasMoved = true;
                numberMoved++;

                if (numberMoved == 3)
                {
                    pcm.DisplayNextTip(3);
                    this.enabled = false;
                }
            }
        }        
    }
}
