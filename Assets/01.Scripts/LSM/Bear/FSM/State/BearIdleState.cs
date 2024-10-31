using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Bear/Idle")]
public class BearIdleState : IdleState
{
    public override void Enter()
    {
        base.Enter();
        int c = Random.Range((int)StateEnum.Pattern1, (int)StateEnum.Pattern1 + _owner.patterns.Count);
        
        //_stateMachine.ChangeState((StateEnum)c);
        _stateMachine.ChangeState(StateEnum.Pattern2);
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