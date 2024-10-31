using System;
using System.Collections;
using UnityEngine;

namespace MK.Boss.State
{
    [CreateAssetMenu(menuName = "SO/Boss/Scorpion/Pattern1")]
    public class TailStingState : Pattern1State, IPatternProbability
    {
        [field: SerializeField] public int PatternProbability { get; set; }

        [SerializeField] private int _attackCount;
        [SerializeField] private float _attackCoolTime;

        private Scorpion _scorpion;
        
        public int AttackCount
        {
            get => _attackCount;
            set { _attackCount = Mathf.Clamp(_attackCount, 0, int.MaxValue); }
        }
        
        public float AttackCoolTime
        {
            get => _attackCoolTime;
            set { _attackCoolTime = Mathf.Clamp(_attackCoolTime, 0, float.MaxValue); }
        }

        private bool _isAttack = false;

        private void OnEnable()
        {
            _scorpion = _owner as Scorpion;
        }

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
            base.Exit();
        }

        private IEnumerator Attack()
        {
            for (int i = 0; i < _attackCount; ++i)
            {
                // TODO : 공격 생성
                yield return new WaitForSeconds(_attackCoolTime);
            }

            _isAttack = true;
            yield return null;
        }
    }
}
