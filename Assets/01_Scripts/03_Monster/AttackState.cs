using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float attackCooldown = 1.0f; 
    private float lastAttackTime;

    public AttackState(Monster monster) : base(monster)
    {
    }

    public override void OnStateEnter()
    {
        animator.SetTrigger(isAttack);
        lastAttackTime = Time.time;
        monster.Attack();
    }

    public override void OnStateUpdate()
    {
        if(Time.time >= lastAttackTime * attackCooldown)
        {
            lastAttackTime = Time.time;
            monster.Attack();
        }
    }
    public override void OnStateExit()
    {
    }
}
