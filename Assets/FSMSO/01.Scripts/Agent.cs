using System.Collections.Generic;
using UnityEngine;
using EasySave.Json;
using Unity.VisualScripting;

[System.Serializable]
public struct Pattern
{
    public string Name;
    public List<GameObject> patternObjs;
}

public class Agent : MonoBehaviour
{

    public StateMachine StateMachine { get; private set; }
    public Animator AnimatorCompo { get; set; }
    public bool CanStateChangeable { get; private set; } = true;
    public bool IsDead { get; private set; }
    [SerializeField] private Pattern[] _patternsStruct;
    public Dictionary<string, List<GameObject>> patterns;


    [SerializeField] private GameObject _mainVisual;
    
    [SerializeField] private List<State> _states;
    
    private void Awake()
    {
        Transform visual = transform.Find("Visual");
        AnimatorCompo = visual.GetComponent<Animator>();
        StateMachine = new StateMachine();
        patterns = new Dictionary<string, List<GameObject>>();

        if(_patternsStruct.Length > 0)
        {
            SetPattern();
        }
        InitStates();
    }

    private void SetPattern()
    {
        foreach(Pattern i in _patternsStruct)
        {
            patterns.Add(i.Name, i.patternObjs);
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
        //Debug.Log("Current State: " + StateMachine.CurrentState);
    }
    
    public void SetStateChangeable(bool value)
    {
        CanStateChangeable = value;
    }
}