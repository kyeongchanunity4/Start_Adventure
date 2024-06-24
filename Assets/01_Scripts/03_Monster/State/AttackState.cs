using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float attackCooldown; 
    private float lastAttackTime;

    public AttackState(Monster monster, float _attackCoolDown) : base(monster)
    {
        this.attackCooldown = _attackCoolDown;
    }

    public override void OnStateEnter()
    {
        animator.SetTrigger(isAttack);
        //animator.SetBool(isAttack, true);
        lastAttackTime = Time.time;
        monster.Attack();

        Debug.Log("Attack Enter!");
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
        //animator.SetBool(isAttack, false);
    }
}
