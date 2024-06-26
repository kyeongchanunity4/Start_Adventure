using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    private float idleTime;
    private float timer = 0f;

    public IdleState(Monster monster, float _idelTime) : base(monster)
    {
        this.idleTime = _idelTime;
    }

    public override void OnStateEnter()
    {
        timer = 0f; 
    }

    public override void OnStateUpdate()
    {
        timer += Time.deltaTime;
        if(timer > idleTime)
        {
            monster.Explore(1);
        }
    }
    public override void OnStateExit()
    {

    }
}
