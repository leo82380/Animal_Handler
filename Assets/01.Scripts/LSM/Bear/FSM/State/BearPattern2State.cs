using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Bear/Pattern2")]
public class BearPattern2State : Pattern2State
{
    public override void Enter()
    {
        base.Enter();

    }
    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
            _stateMachine.ChangeState(StateEnum.Idle);

    }
    public override void Exit()
    {
        base.Exit();
    }
}
