using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public readonly int isIdle = Animator.StringToHash("isIdle");
    public readonly int isMove = Animator.StringToHash("isMove");
    public readonly int isAttack = Animator.StringToHash("isAttack");


    protected Monster monster;
    protected Animator animator;

    protected BaseState(Monster monster)
    {
        this.monster = monster;
        this.animator = monster.GetComponent<Animator>();
    }

    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();
    public abstract void OnStateExit();

}
