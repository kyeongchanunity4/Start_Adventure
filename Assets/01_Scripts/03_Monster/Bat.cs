using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Monster
{
    private enum State
    {
        Idle,
        Fly,
        Attack,
    }

    private State curState;
    private FSM fsm;


}
