using System.Collections;
using UnityEngine;

namespace MK.Boss.State
{
    public class SwingHardState : Pattern6State, IPatternProbability
    {
        [field: SerializeField] public int PatternProbability { get; set; }
        
        [SerializeField] private float _attackChargeTime;

        private bool _isAttack = false;
        
        public override void Enter()
        {
            base.Enter();
            
            _owner.StartCoroutine(Attack());
        }
        
        public override void UpdateState()
        {
            if (_isAttack)
            {
                _owner.StateMachine.ChangeState(StateEnum.Idle);
            }
        }

        public override void Exit()
        {
            _isAttack = false;
            base.Exit();
        }

        private IEnumerator Attack()
        {
            // TODO : 공격 범위
            // 여기안에 커맨드 입력하게
            // 그리고 입력 실패시 진짜 공격
            
            yield return new WaitForSeconds(_attackChargeTime);
            
            // TODO : 공격

            _isAttack = true;
        }
    }
}
