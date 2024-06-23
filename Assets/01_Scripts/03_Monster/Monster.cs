using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;
    public float moveSpeed = 3f;

    public Transform player;
    public Rigidbody2D rigid;

    public float idleTime = 2f;

    public float sightRange = 10f;
    public float attackRange = 2f;
    public float fieldOfView = 120f;
    public LayerMask playerLayerMask;
    public FSM fsm;
    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
        
    }
    public virtual void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void Attack()
    {
        //if (player != null)
        //{
        //    Player playerComponent = player.GetComponent<Player>();
        //    if (playerComponent != null)
        //    {
        //        playerComponent.TakeDamage(damage);
        //    }
        //}
    }
    public virtual bool CanSeePlayer()
    {
        Vector3 directionToPlayer = transform.right;
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, directionToPlayer, sightRange, playerLayerMask);

        foreach (RaycastHit2D hit in hits)
        {
            Debug.DrawRay(transform.position, directionToPlayer * sightRange, Color.red);

            Vector2 directionToHit = (hit.transform.position - transform.position).normalized;
            float distanceToHit = Vector2.Distance(transform.position, hit.transform.position);

            if (distanceToHit <= sightRange)
            {
                float angleToHit = Vector2.Angle(transform.right, directionToHit);
                if (angleToHit <= fieldOfView / 2)
                {
                    if ((playerLayerMask & (1 << hit.collider.gameObject.layer)) != 0)
                    {
                        Debug.DrawLine(transform.position, hit.point, Color.blue);
                        player = hit.collider.gameObject.transform;
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public virtual bool CanAttackPlayer()
    {
        if (player == null) return false;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer <= attackRange;
    }
}
