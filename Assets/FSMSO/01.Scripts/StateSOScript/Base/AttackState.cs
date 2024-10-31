using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Attack")]
public class AttackState : State
{
    public GameObject AttackPrefab;
    public float AttackRange = 5f;
    public int Damage = 10;
    
    public override void Enter()
    {
        base.Enter();
        Attack();
    }

    protected virtual void Attack()
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
        {
            _stateMachine.ChangeState(StateEnum.Idle);
        }
    }
}