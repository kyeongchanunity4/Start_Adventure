using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public readonly int isHit = Animator.StringToHash("isHit");


    [SerializeField] protected int maxHealth = 3;
    public int currentHealth = 3;

    public float moveSpeed = 3f;

    public Transform player;
    protected Rigidbody2D rigid;
    protected Animator anim;
    protected SpriteRenderer spriteRenderer;

    public float idleTime = 2f;
    public float attackTime = 2f;

    public float sightRange = 10f;
    public float attackRange = 2f;
    public float fieldOfView = 120f;

    public float rayDistance = 1f;

    public LayerMask playerLayerMask;
    protected virtual void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }
    protected virtual void Start()
    {
    }

    protected virtual void Update()
    {
        
    }
    public virtual void TakeDamage()
    {
        anim.SetTrigger(isHit);

        currentHealth --;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
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
        //        playerComponent.DecreaseHP();
        //    }
        //}
    }

    public virtual void Explore(int num)
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

    public virtual void OnCollisionEnter2D(Collision2D other)
    {

    }

}
