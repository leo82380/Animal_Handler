using UnityEngine;

namespace MK.Boss.State
{
    public class GrabState : Pattern3State, IPatternProbability
    {
        [field: SerializeField] public int PatternProbability { get; set; }
        
        private bool _isEscape = false;
        
        public override void Enter()
        {
            _isEscape = false;
            base.Enter();
            
            // TODO : 마우스 가운데 고정
            // TODO : 마우스 커맨드 입력하게 하기
        }

        public override void UpdateState()
        {
            if (_isEscape)
            {
                _owner.StateMachine.ChangeState(StateEnum.Idle);
            }
            
            // TODO : 플레이어 도트딜 넣기
        }
    }
}
