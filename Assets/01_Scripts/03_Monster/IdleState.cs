using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(Monster monster) : base(monster)
    {
    }

    public override void OnStateEnter()
    {
        animator.SetBool(isIdle, true);
    }

    public override void OnStateUpdate()
    {
    }
    public override void OnStateExit()
    {
        animator.SetBool(isIdle, false);
    }
}