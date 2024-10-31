using System.Collections;
using UnityEngine;

namespace MK.Boss.State
{
    [CreateAssetMenu(menuName = "SO/Boss/Scorpion/Pattern1")]
    public class TailStingState : Pattern1State, IPatternProbability
    {
        [field: SerializeField] public int PatternProbability { get; set; }

        [SerializeField] private int _attackCount;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private float _radius;

        private Scorpion _scorpion;
        private bool _isAttack = false;
        
        public int AttackCount
        {
            get => _attackCount;
            set { _attackCount = Mathf.Clamp(_attackCount, 0, int.MaxValue); }
        }
        
        public float AttackCoolTime
        {
            get => _attackCooldown;
            set { _attackCooldown = Mathf.Clamp(_attackCooldown, 0, float.MaxValue); }
        }

        private void OnEnable()
        {
            _scorpion = _owner as Scorpion;
        }

        public override void Enter()
        {
            base.Enter();
            _isAttack = false;
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
                // TODO : 공격 범위 생성
                // TODO : 공격 생성
                yield return new WaitForSeconds(_attackCooldown);
            }

            _isAttack = true;
            yield return null;
        }
    }
}
