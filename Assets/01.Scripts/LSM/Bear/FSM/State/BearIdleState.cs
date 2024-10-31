using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Bear/Idle")]
public class BearIdleState : IdleState
{

    public float patternDelayTime;
    private int pattern;

    private float _currentDelayTime;
    public PlayerAttackChoicePanel attackChoicePanel;

    private int _patternCnt;

    public override void Enter()
    {
        base.Enter();
        pattern = Random.Range((int)StateEnum.Pattern1, (int)StateEnum.Pattern1 + _owner.patterns.Count);
        //pattern = Random.Range((int)StateEnum.Pattern1, 2);
        _owner.mainVisual.SetActive(false);
        _patternCnt++;
        if(_patternCnt >= 10)
        {
            _patternCnt = 0;
            attackChoicePanel.Open();
        }
        //_stateMachine.ChangeState((StateEnum)c);
        //_stateMachine.ChangeState(StateEnum.Pattern5);
    }
    public override void UpdateState()
    {
        base.UpdateState();
        _currentDelayTime += Time.deltaTime;
        if (_currentDelayTime >= patternDelayTime)
        {
            _stateMachine.ChangeState((StateEnum)pattern);
            _currentDelayTime = 0;
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}