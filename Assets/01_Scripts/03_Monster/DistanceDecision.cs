using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CreateAssetMenu(menuName = "Monster/Decisions/Distance")]
public class DistanceDecision : Decision
{
    GameObject target;                  
    public string targetTag;               
    public float distanceThreshold = 3f;
    public override bool Decide(BaseStateMachine machine)
    {
        if (target == null) target = GameObject.FindWithTag(targetTag);

        return (Vector3.Distance(machine.transform.position, target.transform.position) >= distanceThreshold) ? true : false;
    }


}
