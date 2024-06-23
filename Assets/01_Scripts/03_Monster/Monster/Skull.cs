using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Skull : Monster
{
    [SerializeField] private float dirValue = 30f;
    [SerializeField] private GameObject projectilePrefab;

    private enum State
    {
        Idle,
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
                if(CanSeePlayer())
                {
                    ChangeState(State.Attack);
                }
                break;
            case State.Attack:
                if(!CanSeePlayer())
                {
                    ChangeState(State.Idle);
                }
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
            case State.Attack:
                fsm.ChangeState(new AttackState(this, attackTime));
                //ThrowProjectile();
                break;
        }
    }

    public override void Attack()
    {
        ThrowProjectile();
    }

    private void ThrowProjectile()
    {
        Vector3 direction = (player.transform.position - this.transform.position);

        SpawnProjectile(direction);

        Vector3 leftDirection = Quaternion.Euler(0, -dirValue, 0) * direction;
        Vector3 rightDirection = Quaternion.Euler(0, dirValue, 0) * direction;

        SpawnProjectile(leftDirection);
        SpawnProjectile(rightDirection);
    }

    private void SpawnProjectile(Vector3 direction)
    {
        GameObject projectile = Instantiate(projectilePrefab, this.transform.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().Init(direction);
    }

    public override bool CanSeePlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, sightRange, playerLayerMask);

        foreach (Collider2D hit in hits)
        {
            Vector2 directionToHit = (hit.transform.position - transform.position).normalized;
            float distanceToHit = Vector2.Distance(transform.position, hit.transform.position);

            if (distanceToHit <= sightRange)
            {
                float angleToHit = Vector2.Angle(transform.right, directionToHit);
                if (angleToHit <= fieldOfView / 2)
                {
                    if ((playerLayerMask & (1 << hit.gameObject.layer)) != 0)
                    {
                        Debug.DrawLine(transform.position, hit.transform.position, Color.blue);
                        player = hit.gameObject.transform;
                        return true;
                    }
                }
            }
        }

        return false;

    }

}
