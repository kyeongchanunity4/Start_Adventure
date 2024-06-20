using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Monster/Transition")]
public class Transition : ScriptableObject
{
    public Decision decision;
    public BaseState TrueState;
    public BaseState FalseState;

    public void Execute(BaseStateMachine stateMachine)
    {
        //if (decision.Decide(stateMachine) && !(TrueState is RemainInState))
        //{
        //    stateMachine.currentState.Exit(stateMachine);
        //    stateMachine.currentState = TrueState;
        //    stateMachine.currentState.Enter(stateMachine);
        //}
        //else if (!(FalseState is RemainInState))
        //{
        //    stateMachine.currentState.Exit(stateMachine);
        //    stateMachine.currentState = FalseState;
        //    stateMachine.currentState.Enter(stateMachine);
        //}
    }
}
