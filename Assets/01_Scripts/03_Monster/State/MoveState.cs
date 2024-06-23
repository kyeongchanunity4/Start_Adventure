using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : BaseState
{
    public readonly int isMove = Animator.StringToHash("isMove");

    private float moveSpeed = 0;
    private Rigidbody2D rigid;
    public MoveState(Monster monster, float _moveSpeed) : base(monster)
    {
        this.moveSpeed = _moveSpeed;
        this.rigid = monster.GetComponent<Rigidbody2D>();
    }

    public override void OnStateEnter()
    {
        animator.SetBool(isMove, true);
    }
    public override void OnStateUpdate()
    {
        if (monster.player != null)
        {
            Vector2 direction = (monster.player.position - monster.transform.position).normalized;
            rigid.velocity = direction * moveSpeed;
        }
    }
    public override void OnStateExit()
    {
        animator.SetBool(isMove, false);
        rigid.velocity = Vector2.zero;
    }

}
