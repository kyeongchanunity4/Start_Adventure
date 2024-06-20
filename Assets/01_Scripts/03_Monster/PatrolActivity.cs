using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Monster/Activity/Patrol")]
public class PatrolActivity : Activity
{
    public float speed = 1;

    public override void Enter(BaseStateMachine machine)
    {
        var PatrolPoints = machine.GetComponent<PatrolPoints>();
        var SpriteRenderer = machine.GetComponent<SpriteRenderer>();
        var Animator = machine.GetComponent<Animator>();
        SpriteRenderer.flipX = (PatrolPoints.GetTargetPointDirection().x > 0) ? true : false;
        Animator.SetBool("isWalk", true);
    }

    public override void Execute(BaseStateMachine machine)
    {
        var PatrolPoints = machine.GetComponent<PatrolPoints>();
        var rigid = machine.GetComponent<Rigidbody2D>();
        float x = PatrolPoints.GetTargetPointDirection().x;

        Vector2 position = rigid.position + new Vector2(x * speed * Time.fixedDeltaTime, rigid.position.y);
        rigid.MovePosition(position);
    }
    public override void Exit(BaseStateMachine machine)
    {
        var PatrolPoints = machine.GetComponent<PatrolPoints>();
        PatrolPoints.SetNextTargetPoint();
    }
}

