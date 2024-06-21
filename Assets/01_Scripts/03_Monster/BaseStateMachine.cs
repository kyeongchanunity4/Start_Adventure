using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStateMachine : MonoBehaviour
{
    [SerializeField] private BaseStatePre initState;
    public BaseStatePre currentState { get; set; }
    
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
