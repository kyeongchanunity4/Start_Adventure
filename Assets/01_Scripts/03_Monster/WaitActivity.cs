using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Monster/Activity/Wait")]
public class WaitActivity : Activity
{
    public override void Enter(BaseStateMachine machine)
    {
        machine.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        machine.GetComponent<Animator>().SetBool("isWalk", false);
    }

    public override void Execute(BaseStateMachine machine)
    {
        
    }
    public override void Exit(BaseStateMachine machine)
    {
        
    }
}
