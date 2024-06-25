using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FlyState : BaseState
{
    public readonly int isMove = Animator.StringToHash("isMove");

    private float moveSpeed = 0;
    private bool isMoveRightMove = true;
    private float rayDistance = 1f;
    public float randomMoveRadius = 5f;

    private float moveDuration = 5f;
    private float moveTimer = 0f;
    private Vector2 randomTargetPosition;

    private Rigidbody2D rigid;
    public FlyState(Monster monster, float _moveSpeed) : base(monster)
    {
        this.moveSpeed = _moveSpeed;
        this.rigid = monster.GetComponent<Rigidbody2D>();
        this.moveTimer = moveDuration;
        this.isMoveRightMove = !spriteRenderer.flipX;
        SetRandomTargetPosition();
    }

    public override void OnStateEnter()
    {
        animator.SetBool(isMove, true);
        moveTimer = moveDuration;
        
    }
    public override void OnStateUpdate()
    {
        moveTimer -= Time.deltaTime;

        if (moveTimer <= 0)
        {
            monster.Explore(0);
            return;
        }
        if (monster.player != null)
        {
            Vector2 direction = (monster.player.position - monster.transform.position).normalized;
            rigid.velocity = direction * moveSpeed;

            spriteRenderer.flipX = direction.x < 0;
        }
        else
        {
            if (Vector2.Distance(monster.transform.position, randomTargetPosition) < 0.1f)
            {
                SetRandomTargetPosition();
            }

            Vector2 direction = (randomTargetPosition - (Vector2)monster.transform.position).normalized;
            rigid.velocity = direction * moveSpeed;
            spriteRenderer.flipX = direction.x < 0;

            RaycastHit2D hit = Physics2D.Raycast(monster.transform.position, direction, rayDistance, LayerMask.GetMask("Ground"));

            Debug.DrawRay(monster.transform.position, direction * rayDistance, Color.red);
            if (hit.collider != null)
            {
                SetRandomTargetPosition();
            }
        }
    }

    private void SetRandomTargetPosition()
    {
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        randomTargetPosition = (Vector2)monster.transform.position + randomDirection * randomMoveRadius;
    }

    public override void OnStateExit()
    {
        Debug.Log("Move OnState Exit");
        animator.SetBool(isMove, false);
        rigid.velocity = Vector2.zero;
    }
}
