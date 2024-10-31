using System.Collections;
using ObjectPooling;
using UnityEngine;

namespace MK.Boss.State
{
    public class TargetStingState : Pattern4State, IPatternProbability
    {
        [field: SerializeField] public int PatternProbability { get; set; }
        
        [SerializeField] private int _attackCount;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private float _radius;

        private bool _isAttack = false;

        private Player _player;
        
        public override void Enter()
        {
            base.Enter();
            // TODO : Player Position 찾기
            _player = FindObjectOfType<Player>();
            
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
            for (int i = 0; i < _attackCount; ++i)
            {
                // TODO : Attack
                // TODO : AttackLoad 원으로 바꾸기
                AttackLoad attackLoad = PoolingManager.Instnace.Pop(PoolingType.TailSwing_AttackLoad) as AttackLoad;
                attackLoad.transform.position = _player.transform.position;
                
                yield return new WaitForSeconds(_attackCooldown);
            }

            _isAttack = true;
        }
    }
}
