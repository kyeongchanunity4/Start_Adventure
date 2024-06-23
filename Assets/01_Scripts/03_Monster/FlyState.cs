using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyState : BaseState
{
    public readonly int isFly = Animator.StringToHash("isFly");
    private float moveSpeed = 0f;
    public FlyState(Monster monster, float moveSpeed) : base(monster)
    {
        this.moveSpeed = moveSpeed;
    }

    public override void OnStateEnter()
    {
        animator.SetBool(isFly, true);
    }

    public override void OnStateUpdate()
    {
    }

    public override void OnStateExit()
    {
        animator.SetBool(isFly, false);
    }
}
