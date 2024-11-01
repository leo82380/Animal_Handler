using System.Collections;
using MK.Boss.Pattern;
using ObjectPooling;
using UnityEngine;

namespace MK.Boss.State
{
    [CreateAssetMenu(menuName = "SO/Boss/Scorpion/Pattern1")]
    public class TailStingState : Pattern1State, IPatternProbability
    {
        [field: SerializeField] public int PatternProbability { get; set; }

        [SerializeField] private int _attackCount;
        [SerializeField] private float _attackLoadTime;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private int _radiusMin;
        [SerializeField] private int _radiusMax;

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
                AttackLoadCircle attackLoadCircle = PoolingManager.Instnace.Pop(PoolingType.AttackLoad_Circle) as AttackLoadCircle;
                attackLoadCircle.RadiusAndPositionAttack(Mathf.Clamp(Random.Range(_radiusMin, _radiusMax + 1), 1, int.MaxValue), true);
                
                yield return new WaitForSeconds(_attackLoadTime);
                
                attackLoadCircle.RealAttack();
                
                yield return new WaitForSeconds(_attackCooldown);
            }

            _isAttack = true;
            yield return null;
        }
    }
}
