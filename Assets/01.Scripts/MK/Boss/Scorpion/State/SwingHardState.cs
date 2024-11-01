using System.Collections;
using ObjectPooling;
using UnityEngine;

namespace MK.Boss.State
{
    [CreateAssetMenu(menuName = "SO/Boss/Scorpion/Pattern6")]
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
            PoolingManager.Instnace.Pop(PoolingType.SwingHard);
            yield return new WaitForSeconds(_attackChargeTime);

            _isAttack = true;
        }
    }
}
