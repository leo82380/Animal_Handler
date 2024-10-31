using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAnimationTrigger : MonoBehaviour
{
    private Agent _agent;

    private void Awake()
    {
        _agent = transform.root.GetComponent<Agent>();
    }

    public void AnimationEnd()
    {
        _agent.StateMachine.CurrentState.AanimationEnd();
    }
}
