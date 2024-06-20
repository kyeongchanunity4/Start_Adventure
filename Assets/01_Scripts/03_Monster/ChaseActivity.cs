using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Monster/Activity/Patrol")]
public class ChaseActivity : Activity
{
    GameObject target;     
    public string targetTag;  
    public float speed = 1;

    public override void Enter(BaseStateMachine machine)
    {
        target = GameObject.FindWithTag(targetTag);
        machine.GetComponent<Animator>().SetBool("isWalk", true);
    }

    public override void Execute(BaseStateMachine machine)
    {
        var RigidBody = machine.GetComponent<Rigidbody2D>();
        var SpriteRenderer = machine.GetComponent<SpriteRenderer>();

        Vector2 dir = (target.transform.position - machine.transform.position).normalized;
        RigidBody.velocity = new Vector2(dir.x * speed, RigidBody.velocity.y);
        SpriteRenderer.flipX = (dir.x > 0) ? true : false;
    }

    public override void Exit(BaseStateMachine machine)
    {
        throw new System.NotImplementedException();
    }

}
