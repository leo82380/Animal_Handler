using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Dead")]
public class DeadState : State
{
    public override void Enter()
    {
        Dead();
        base.Enter();
    }

    protected virtual void Dead()
    {
        _owner.SetStateChangeable(false);
    }
}