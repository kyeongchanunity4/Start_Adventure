using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Monster/State")]
public class State : BaseStatePre
{
    public List<Activity> activitys = new List<Activity>();
    public List<Transition> transitions = new List<Transition>();

    public override void Enter(BaseStateMachine machine)
    {
        foreach (var activity in activitys)
            activity.Enter(machine);
    }
    public override void Execute(BaseStateMachine machine)
    {
        foreach (var activity in activitys)
            activity.Execute(machine);

        foreach (var transition in activitys)
            transition.Execute(machine);
    }

    public override void Eixt(BaseStateMachine machine)
    {
        foreach (var activity in activitys)
            activity.Exit(machine);
    }
}
