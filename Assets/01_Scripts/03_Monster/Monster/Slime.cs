using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
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
                //else ChangeState(State.Move);
                break;
            case State.Move:
                if (CanSeePlayer())
                {
                    if (CanAttackPlayer())
                        ChangeState(State.Attack);
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
                fsm.ChangeState(new MoveState(this, moveSpeed, rayDistance));
                break;
            case State.Attack:
                fsm.ChangeState(new AttackState(this, attackTime));
                break;
        }
    }

    public override void Explore(int num)
    {
        switch(num)
        {
            case (int)State.Idle:
                ChangeState(State.Idle);
                break;
            case (int)State.Move:
                ChangeState(State.Move);
                break;
        }
    }

    public override bool CanSeePlayer()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, sightRange, playerLayerMask);

        foreach (Collider2D collider in colliders)
        {
            Transform target = collider.transform;
            Vector2 directionToPlayer = (target.position - transform.position).normalized;
            float distanceToPlayer = Vector2.Distance(transform.position, target.position);

            if (distanceToPlayer <= sightRange)
            {
                Vector2 sightDirection = spriteRenderer.flipX ? -transform.right : transform.right;

                float angleToPlayer = Vector2.Angle(sightDirection, directionToPlayer);

                if (angleToPlayer <= fieldOfView / 2)
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, sightRange, playerLayerMask);

                    Debug.DrawRay(transform.position, directionToPlayer * sightRange, Color.red);
                    if (hit.collider != null)
                    {
                        Debug.DrawLine(transform.position, hit.point, Color.blue);
                    }

                    if (hit.collider != null && hit.collider.transform == target)
                    {
                        player = target;
                        return true;
                    }
                }
            }
        }

        if (player != null)
            player = null;

        return false;
    }
}
