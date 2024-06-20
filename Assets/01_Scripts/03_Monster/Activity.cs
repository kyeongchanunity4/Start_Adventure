using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activity : ScriptableObject
{
    public abstract void Enter(BaseStateMachine machine);
    public abstract void Execute(BaseStateMachine machine);
    public abstract void Exit(BaseStateMachine machine);
}
