using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected float maxHealth = 100f;
    public float currentHealth = 100f;
    public float damage = 10f;
    public float moveSpeed = 3f;

    public Transform player;
    private Rigidbody2D rigid;

    public float idleTime = 2f;
    public float attackTime = 5f;

    public float sightRange = 10f;
    public float attackRange = 2f;
    public float fieldOfView = 120f;
    public LayerMask playerLayerMask;
    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }
    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
        
    }
    public virtual void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
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

    public virtual void Explore()
    {

    }

    public virtual bool CanSeePlayer()
    {
        return false;
    }

    public virtual bool CanAttackPlayer()
    {
        if (player == null) return false;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer <= attackRange;
    }


}
