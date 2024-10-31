using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Move")]
public class MoveState : State
{
    public float MoveSpeed = 5f;
    public float MoveRange = 10f;

    public override void Enter()
    {
        base.Enter();
        Move();
    }

    protected virtual void Move()
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
        {
            _stateMachine.ChangeState(StateEnum.Attack);
        }
    }
}