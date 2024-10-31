using System.Collections;
using UnityEngine;

namespace MK.Boss.State
{
    public class ToxicExplosionState : Pattern5State, IPatternProbability
    {
        [field: SerializeField] public int PatternProbability { get; set; }
        
        [SerializeField] private float _attackCooldown;
        [SerializeField] private float _radius;

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
            // spritemask로 없애고 그 범위로 콜라이더 해서 조지면 될듯
            
            yield return new WaitForSeconds(_attackCooldown);
            
            // TODO : 공격

            _isAttack = true;
        }
    }
}

