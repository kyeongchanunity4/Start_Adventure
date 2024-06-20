using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Monster/Decisions/InLine")]
public class InLineOfSightDecision : Decision
{
    public LayerMask layerMask;
    public float distanceThreshold = 3f;
    Vector3 prevPosition = Vector3.zero;
    Vector3 prevDir = Vector3.zero;
    public override bool Decide(BaseStateMachine machine)
    {
        Vector3 dir = (machine.transform.position - prevPosition).normalized;
        dir = (dir.Equals(Vector3.zero)) ? prevDir : dir;
        RaycastHit2D hit = Physics2D.Raycast(machine.transform.position, dir, distanceThreshold, layerMask);
        prevPosition = machine.transform.position;
        prevDir = dir;
        return (hit.collider != null) ? true : false;
    }
}
