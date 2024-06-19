using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine : MonoBehaviour
{
    [SerializeField] private BaseState initState;
    public BaseState currentState { get; set; }
    
    private void Awake()
    {
        currentState = initState;
    }

    private void Start()
    {
        currentState.Enter(this);
    }

    private void Update()
    {
        currentState.Execute(this);
    }
}
