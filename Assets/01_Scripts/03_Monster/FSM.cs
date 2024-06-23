using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM
{
    private BaseState curState;
    public FSM(BaseState initState)
    {
        curState = initState;
        ChangeState(curState);
    }

    public void ChangeState(BaseState nextState)
    {
        if (nextState == curState)
            return;

        if (curState != null)
            curState.OnStateExit();

        curState = nextState;
        curState.OnStateEnter();
    }

    public void UpdateState()
    {
        curState?.OnStateUpdate();
    }
}
