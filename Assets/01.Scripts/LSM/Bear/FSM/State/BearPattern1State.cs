using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Bear/Pattern1")]
public class BearPattern1State : Pattern1State
{

    public Transform[] Pattern1;
    public Transform[] Pattern2;

    public override void Initialize(StateMachine stateMachine, Agent owner, string animBoolName)
    {
        base.Initialize(stateMachine, owner, animBoolName);
    }

    public override void Enter()
    {
        base.Enter();
        int c = Random.Range(0, _owner.patterns["Pattern1"].Count);
        _owner.AnimatorCompo.SetInteger("Rand", c);
        //if(c == 0)
        //{
        //    foreach (Transform i in Pattern1)
        //    {
        //        i.transform.position = PlayerManager.Instnace.transform.position;
        //        Debug.Log(1);
        //    }

        //}
        //else if (c == 1)
        //{
        //    foreach (Transform i in Pattern2)
        //    {
        //        i.transform.position = PlayerManager.Instnace.transform.position;
        //        Debug.Log(2);
        //    }
        //}
        

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