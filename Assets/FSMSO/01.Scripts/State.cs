using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class State : ScriptableObject
{
    public StateEnum StateEnum;
    protected StateMachine _stateMachine;
    protected Agent _owner;
    protected bool _endTriggerCalled;
    protected int _animBoolHash;
    
    public virtual void Initialize(StateMachine stateMachine, Agent owner, string animBoolName)
    {
        _stateMachine = stateMachine;
        _owner = owner;
        _animBoolHash = Animator.StringToHash(animBoolName);
    }
    
    public virtual void UpdateState()
    {
    }
    
    public virtual void Enter()
    {
        _endTriggerCalled = false;
        _owner.AnimatorCompo.SetBool(_animBoolHash, true);
    }
    
    public virtual void Exit()
    {
        _owner.AnimatorCompo.SetBool(_animBoolHash, false);
    }
}