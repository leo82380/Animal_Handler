using System.Collections.Generic;
using System;

public class StateMachine
{
    public State CurrentState { get; private set; }
    public Dictionary<StateEnum, State> StateDictionary = new Dictionary<StateEnum, State>();
    private Agent _owner;
    
    public void Initialize(StateEnum startState, Agent owner)
    {
        _owner = owner;
        CurrentState = StateDictionary[startState];
        CurrentState.Enter();
    }
    
    public void ChangeState(StateEnum newState, bool forceMode = false)
    {
        if (_owner.CanStateChangeable == false && forceMode == false) return;
        if (_owner.IsDead) return;
    
        CurrentState.Exit();
        CurrentState = StateDictionary[newState];
        CurrentState.Enter();
    }
    
    public void AddState(StateEnum stateEnum, State state)
    {
        StateDictionary.Add(stateEnum, state);
    }
}
