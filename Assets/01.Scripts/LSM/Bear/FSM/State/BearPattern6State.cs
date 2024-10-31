
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Bear/Pattern6")]
public class BearPattern6State : Pattern6State
{
    public override void Enter()
    {
        base.Enter();
        int c = Random.Range(0, _owner.patterns["Pattern1"].Count);
        _owner.AnimatorCompo.SetInteger("Rand", c);
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
