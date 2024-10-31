using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Bear/Idle")]
public class BearIdleState : IdleState
{
    public override void Enter()
    {
        base.Enter();
        _stateMachine.ChangeState(StateEnum.Pattern6);
    }
    public override void UpdateState()
    {
        base.UpdateState();
    }
    public override void Exit()
    {
        base.Exit();
    }
}