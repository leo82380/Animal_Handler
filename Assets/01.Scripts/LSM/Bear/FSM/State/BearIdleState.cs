using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Bear/Idle")]
public class BearIdleState : IdleState
{

    public float patternDelayTime;
    private int pattern;

    private float _currentDelayTime;
    public PlayerAttackChoicePanel attackChoicePanel;

    private int _patternCnt = 0;
    private bool _isOpenSelect;
    public int patternEvasionCnt;

    public override void Initialize(StateMachine stateMachine, Agent owner, string animBoolName)
    {
        base.Initialize(stateMachine, owner, animBoolName);
        attackChoicePanel  = FindObjectOfType<PlayerAttackChoicePanel>();
        attackChoicePanel.gameObject.SetActive(false);
        _patternCnt = 0;
        _isOpenSelect = false;
    }

    public override void Enter()
    {
        base.Enter();
        pattern = Random.Range((int)StateEnum.Pattern1, (int)StateEnum.Pattern1 + _owner.patterns.Count);
        //pattern = Random.Range((int)StateEnum.Pattern1, 2);
        
        if(_patternCnt >= patternEvasionCnt)
        {
            _isOpenSelect = true;
            _patternCnt = 0;
            attackChoicePanel.Open();
        }
        //_stateMachine.ChangeState((StateEnum)c);
        //_stateMachine.ChangeState(StateEnum.Pattern5);
    }
    public override void UpdateState()
    {
        base.UpdateState();
        if(!_isOpenSelect)
        {
            _currentDelayTime += Time.deltaTime;
            if (_currentDelayTime >= patternDelayTime)
            {
                if(_owner.mainVisual.activeSelf)
                {
                    _owner.mainVisual.SetActive(false);
                }
                _stateMachine.ChangeState((StateEnum)pattern);
                _currentDelayTime = 0;
            }
        }
        if(!attackChoicePanel.gameObject.activeSelf)
        {
            _isOpenSelect = false;
        }
    }
    public override void Exit()
    {
        _patternCnt++;

        base.Exit();
    }
}