using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class MoveState : BaseState
{
    public readonly int isMove = Animator.StringToHash("isMove");

    private float moveSpeed = 0;
    private bool isMoveRightMove = true;
    private float rayDistance = 1f;

    private float moveDuration = 5f;
    private float moveTimer = 0f;

    private Rigidbody2D rigid;
    public MoveState(Monster monster, float _moveSpeed, float _rayDeistance) : base(monster)
    {
        this.moveSpeed = _moveSpeed;
        this.rigid = monster.GetComponent<Rigidbody2D>();
        this.moveTimer = moveDuration;
        this.isMoveRightMove = !spriteRenderer.flipX;
        this.rayDistance = _rayDeistance;
    }

    public override void OnStateEnter()
    {
        animator.SetBool(isMove, true);
        moveTimer = moveDuration;

    }
    public override void OnStateUpdate()
    {
        /*
        moveTimer -= Time.deltaTime;

        if(moveTimer <= 0)
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
            Vector2 direction = isMoveRightMove ? Vector2.right : Vector2.left;
            rigid.velocity = direction * moveSpeed;

            RaycastHit2D hitFront = Physics2D.Raycast(monster.transform.position, direction, rayDistance, LayerMask.GetMask("Ground"));
            Debug.DrawRay(monster.transform.position, direction * rayDistance, Color.red);

            bool monsterCheck = monster is Slime;
            RaycastHit2D hitDown = new RaycastHit2D();
            if (monsterCheck)
            {
                Vector2 dirDown = Vector2.down;
                hitDown = Physics2D.Raycast((Vector2)monster.transform.position + direction * rayDistance, dirDown, rayDistance, LayerMask.GetMask("Ground"));
                Debug.DrawRay(monster.transform.position, dirDown * rayDistance, Color.yellow);
            }
            
            if (hitFront.collider != null || (monsterCheck && hitDown.collider == null))
            {
                isMoveRightMove = !isMoveRightMove;
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }*/

        moveTimer -= Time.deltaTime;

        if (moveTimer <= 0)
        {
            monster.Explore(0);
            return;
        }

        Vector2 direction;

        if (monster.player != null)
        {
            direction = (monster.player.position - monster.transform.position).normalized;
            rigid.velocity = direction * moveSpeed;

            spriteRenderer.flipX = direction.x < 0;
        }
        else
        {
            direction = isMoveRightMove ? Vector2.right : Vector2.left;
            rigid.velocity = direction * moveSpeed;
        }

        RaycastHit2D hitFront = Physics2D.Raycast(monster.transform.position, direction, rayDistance, LayerMask.GetMask("Ground"));
        Debug.DrawRay(monster.transform.position, direction * rayDistance, Color.red);

        bool monsterCheck = monster is Slime;
        RaycastHit2D hitDown = new RaycastHit2D();
        if (monsterCheck)
        {
            Vector2 dirDown = Vector2.down;
            hitDown = Physics2D.Raycast((Vector2)monster.transform.position + direction * rayDistance, dirDown, rayDistance, LayerMask.GetMask("Ground"));
            Debug.DrawRay((Vector2)monster.transform.position + direction * rayDistance, dirDown * rayDistance, Color.yellow);
        }

        if (hitFront.collider != null || (monsterCheck && hitDown.collider == null))
        {
            isMoveRightMove = !isMoveRightMove;
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }
    public override void OnStateExit()
    {
        Debug.Log("Move OnState Exit");
        animator.SetBool(isMove, false);
        rigid.velocity = Vector2.zero;
    }
}
