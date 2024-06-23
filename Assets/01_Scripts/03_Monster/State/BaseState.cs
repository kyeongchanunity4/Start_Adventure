using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public readonly int isIdle = Animator.StringToHash("isIdle");
    public readonly int isAttack = Animator.StringToHash("isAttack");


    protected Monster monster;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    protected BaseState(Monster monster)
    {
        this.monster = monster;
        this.animator = monster.GetComponent<Animator>();
        this.spriteRenderer = monster.GetComponent<SpriteRenderer>();
    }

    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();
    public abstract void OnStateExit();

}
