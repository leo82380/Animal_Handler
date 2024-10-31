using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Eagle/Idle")]
public class EagleIdleState : IdleState
{
    public override void Enter()
    {
        base.Enter();
        _owner.StartCoroutine(SetRandomState());
    }

    private IEnumerator SetRandomState()
    {
        yield return new WaitForSeconds(5f);
        //_stateMachine.ChangeState((StateEnum)Random.Range((int)StateEnum.Pattern1, (int)StateEnum.Pattern6 + 1));
        _stateMachine.ChangeState(StateEnum.Pattern3);
    }
}
