using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Monster/Decisions/Reached")]
public class ReachedWaypointDecision : Decision
{
    public override bool Decide(BaseStateMachine machine)
    {
        return (machine.GetComponent<PatrolPoints>().HasReachedPoint()) ? true : false;
    }
}
