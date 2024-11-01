using System.Collections;
using MK.Boss.Pattern;
using ObjectPooling;
using UnityEngine;

namespace MK.Boss.State
{
    [CreateAssetMenu(menuName = "SO/Boss/Scorpion/Pattern5")]
    public class ToxicExplosionState : Pattern5State, IPatternProbability
    {
        [field: SerializeField] public int PatternProbability { get; set; }
        
        [SerializeField] private float _attackLoadTime;
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
            ToxicFlooringLoad toxicLoad = PoolingManager.Instnace.Pop(PoolingType.ToxicFlooringLoad) as ToxicFlooringLoad;
            toxicLoad.RandomAttackPostion();
            
            yield return new WaitForSeconds(_attackLoadTime);
            
            toxicLoad.RealAttack();
            
            yield return new WaitForSeconds(_attackCooldown);

            _isAttack = true;
        }
    }
}

