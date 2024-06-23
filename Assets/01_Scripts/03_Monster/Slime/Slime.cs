using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Slime : Monster
{
    private enum State
    {
        Idle,
        Move,
        Attack,
    }

    private State curState;
    private FSM fsm;

    //public float sightRange = 10f;
    //public float attackRange = 2f;
    //public float fieldOfView = 120f;
    //public LayerMask playerLayerMask;

    protected override void Start()
    {
        curState = State.Idle;
        fsm = new FSM(new IdleState(this, idleTime));
    }

    protected override void Update()
    {
        switch (curState)
        {
            case State.Idle:
                if (CanSeePlayer())
                {
                    if (CanAttackPlayer())
                        ChangeState(State.Attack);
                    else
                        ChangeState(State.Move);
                }
                break;
            case State.Move:
                if (CanSeePlayer())
                {
                    if (CanAttackPlayer())
                        ChangeState(State.Attack);
                }
                else
                {
                    ChangeState(State.Idle);
                }
                break;
            case State.Attack:
                if (CanSeePlayer())
                {
                    if (!CanAttackPlayer())
                        ChangeState(State.Move);
                }
                else
                    ChangeState(State.Idle);
                break;
        }
        fsm.UpdateState();
    }

    private void ChangeState(State nextState)
    {
        curState = nextState;

        switch (curState)
        {
            case State.Idle:
                fsm.ChangeState(new IdleState(this, idleTime));
                break;
            case State.Move:
                fsm.ChangeState(new MoveState(this, moveSpeed));
                break;
            case State.Attack:
                fsm.ChangeState(new AttackState(this));
                break;
        }
 
    }
}
