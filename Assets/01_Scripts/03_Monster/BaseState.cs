using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : ScriptableObject
{
    public virtual void Enter(BaseStateMachine machine) { } //Enter State
    public virtual void Execute(BaseStateMachine machine) { } //State Behavior
    public virtual void Eixt(BaseStateMachine machine) { } //Exit State
}
