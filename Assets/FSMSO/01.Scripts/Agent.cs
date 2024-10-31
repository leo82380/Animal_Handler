using System.Collections.Generic;
using UnityEngine;
using EasySave.Json;

public class Agent : MonoBehaviour
{
    public StateMachine StateMachine { get; private set; }
    public Animator AnimatorCompo { get; private set; }
    public bool CanStateChangeable { get; private set; } = true;
    public bool IsDead { get; private set; }
    
    [SerializeField] protected List<State> _states;
    
    private void Awake()
    {
        AnimatorCompo = GetComponent<Animator>();
        StateMachine = new StateMachine();
        
        InitStates();
    }

    private void InitStates()
    {
        foreach (var state in _states)
        {
            state.Initialize(StateMachine, this, state.name);
            Debug.Log("State Name: " + state.name);
            StateMachine.AddState(state.StateEnum, state);
        }
        
        StateMachine.Initialize(StateEnum.Idle, this);
    }

    private void Update()
    {
        StateMachine.CurrentState.UpdateState();
        Debug.Log("Current State: " + StateMachine.CurrentState);
    }
    
    public void SetStateChangeable(bool value)
    {
        CanStateChangeable = value;
    }
}