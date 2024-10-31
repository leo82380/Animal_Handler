using System.Collections.Generic;
using UnityEngine;
using EasySave.Json;
using Unity.VisualScripting;

[System.Serializable]
public struct Pattern
{
    public string name;
    public List<GameObject> patternObj;
}


public class Agent : MonoBehaviour
{

    public StateMachine StateMachine { get; private set; }
    public Animator AnimatorCompo { get; private set; }
    public bool CanStateChangeable { get; private set; } = true;
    public bool IsDead { get; private set; }
    [SerializeField] Pattern[] _patterns;
    [SerializeField] private GameObject _mainVisual;
    private Dictionary<string,List<GameObject>> _patternDictionary;
    
    [SerializeField] private List<State> _states;
    
    private void Awake()
    {
        AnimatorCompo = GetComponent<Animator>();
        StateMachine = new StateMachine();
        _patternDictionary =    new Dictionary<string,List<GameObject>>();



        InitStates();
    }

    private void SetPatternObj()
    {
        foreach(Pattern i in _patterns)
        {
            _patternDictionary.Add(i.name, i.patternObj);
        }
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