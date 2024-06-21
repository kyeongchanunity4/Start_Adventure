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

    public float sightRange = 10f;
    public float attackRange = 2f;
    public float fieldOfView = 120f;
    private Transform player;

    protected override void Start()
    {
        curState = State.Idle;
        fsm = new FSM(new IdleState(this));
    }

    protected override void Update()
    {
        switch (curState)
        {
            case State.Idle:
                if(CanSeePlayer())
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
    }

    private void ChangeState(State nextState)
    {
        curState= nextState;
        switch (curState)
        {
            case State.Idle:
                fsm.ChangeState(new IdleState(this));
                break;
            case State.Move:
                fsm.ChangeState(new MoveState(this, moveSpeed));
                break;
            case State.Attack:
                fsm.ChangeState(new AttackState(this));
                break;
        }
    }


    private bool CanSeePlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= sightRange)
        {
            float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);
            if (angleToPlayer <= fieldOfView / 2)
            {
                if (Physics.Raycast(transform.position, directionToPlayer, out RaycastHit hit, sightRange))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        player = hit.transform;
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private bool CanAttackPlayer()
    {
        if (player == null) return false;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer <= attackRange;
    }



}
