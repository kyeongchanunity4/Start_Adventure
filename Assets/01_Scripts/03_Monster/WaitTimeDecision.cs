using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WaitTimeDecision : Decision
{
    public float waitTime = 3f;
    private float timer = 0;

    public override bool Decide(BaseStateMachine machine)
    {
        timer += Time.deltaTime;
        if(timer >= waitTime)
        {
            timer = 0;
            return true;
        }
        else
        {
            return false;
        }
    }
}
