using System.Collections;
using MK.Boss.Pattern;
using ObjectPooling;
using UnityEngine;

namespace MK.Boss.State
{
    [CreateAssetMenu(menuName = "SO/Boss/Scorpion/Pattern4")]
    public class TargetStingState : Pattern4State, IPatternProbability
    {
        [field: SerializeField] public int PatternProbability { get; set; }
        
        [SerializeField] private int _attackCount;
        [SerializeField] private float _attackLoadTime;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private int _radiusMin;
        [SerializeField] private int _radiusMax;

        private bool _isAttack = false;

        private Player _player;
        
        public override void Enter()
        {
            base.Enter();
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
                AttackLoadCircle attackLoadCircle = PoolingManager.Instnace.Pop(PoolingType.AttackLoad_Circle) as AttackLoadCircle;

                attackLoadCircle.transform.position = _player.transform.position;
                attackLoadCircle.RadiusAndPositionAttack(Mathf.Clamp(Random.Range(_radiusMin, _radiusMax + 1), 1, int.MaxValue));
                
                yield return new WaitForSeconds(_attackLoadTime);
                
                attackLoadCircle.RealAttack();
                
                yield return new WaitForSeconds(_attackCooldown);
            }

            _isAttack = true;
        }
    }
}
