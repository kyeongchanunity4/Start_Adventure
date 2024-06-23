using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Monster
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject stonePrefab;
    private enum State
    {
        Idle,
        Move,
        Attack,
    }

    private State curState;
    private FSM fsm;

    private bool dropStone = false;
    private bool rangedAttack = false;

    [Header("AnimationController")]
    public Animator[] animator;

    [Header("MeleeAttackValue")]
    [SerializeField] private float pushBackForce = 10f;
    [SerializeField] private float pushBackDistance = 5f;

    [Header("StoneAttackValue")]
    [SerializeField] private Vector3 minValue = Vector3.zero;
    [SerializeField] private Vector3 maxValue = Vector3.zero;

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
            case State.Attack:
                fsm.ChangeState(new AttackState(this, attackTime));
                break;
        }
    }
    public override void Explore()
    {
        ChangeState(State.Move);
    }

    public override void Attack()
    {
        CheckHealthAndSkill();
        UseSkill();
    }

    private void CheckHealthAndSkill()
    {
        if(currentHealth <= maxHealth * 0.5f && !dropStone)
        {
            dropStone = true;
        }
        else if(currentHealth <= maxHealth * 0.2f && !rangedAttack)
        {
            rangedAttack = true;
        }
    }

    private void UseSkill()
    {
        if (dropStone)
        {
            UseDropStone();
            return;
        }

        if (rangedAttack)
        {
            float distancePlayer = Vector3.Distance(transform.position, player.transform.position);

            if (distancePlayer >= 3f)
            {
                ThrowProjectile();
            }
            else
            {
                UseDropStone();
            }
        }

        UseMeleeAttackSkill();
    }

    private void UseDropStone()
    {
        float randomCount = Random.Range(1, 5);         
        float height = minValue.y;

        for(int i = 0; i < randomCount; i++)
        {
            float randomX = Random.Range(minValue.x, maxValue.x);
            Vector3 spawnPos = new Vector3(randomX, height, 0);
            Instantiate(stonePrefab, spawnPos, Quaternion.identity);
        }

        Debug.Log("Boss >> Drop Stone!");

        dropStone = false;
    }

    private void UseMeleeAttackSkill()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, sightRange, playerLayerMask);
        foreach (Collider2D hit in hits)
        {
            if ((playerLayerMask & (1<< hit.gameObject.layer)) != 0)
            {
                Vector3 direction = (hit.transform.position - transform.position).normalized;
                hit.GetComponent<Rigidbody2D>().AddForce(direction * pushBackForce, ForceMode2D.Impulse);

                Vector3 pushBackPosition = transform.position + direction * pushBackDistance;
                hit.transform.position = pushBackPosition;
            }
        }

        Debug.Log("Boss > MeleeAttack!");
    }

    private void ThrowProjectile()
    {
        if (player == null) return;

        Vector3 direction = (player.transform.position - this.transform.position);

        UseRangedAttackSkill(direction);

        Debug.Log("Boss >> ThrowProjectTile!");
    }

    private void UseRangedAttackSkill(Vector3 direction)
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