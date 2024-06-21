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
    public LayerMask playerLayerMask;

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
        Vector3 directionToPlayer = transform.forward;
        RaycastHit[] hits = Physics.RaycastAll(transform.position, directionToPlayer, sightRange, playerLayerMask);

        foreach (RaycastHit hit in hits)
        {
            Vector3 directionToHit = (hit.transform.position - transform.position).normalized;
            float distanceToHit = Vector3.Distance(transform.position, hit.transform.position);

            if (distanceToHit <= sightRange)
            {
                float angleToHit = Vector3.Angle(transform.forward, directionToHit);
                if (angleToHit <= fieldOfView / 2)
                {
                    if ((playerLayerMask & (1 << hit.collider.gameObject.layer)) != 0)
                    {
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
