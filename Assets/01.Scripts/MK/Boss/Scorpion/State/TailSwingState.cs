using System.Collections;
using ObjectPooling;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MK.Boss.State
{
    [CreateAssetMenu(menuName = "SO/Boss/Scorpion/Pattern2")]
    public class TailSwingState : Pattern2State, IPatternProbability
    {
        [field: SerializeField] public int PatternProbability { get; set; }
        [SerializeField] private float _attackLoadTime;
        [SerializeField] private float _attackCooldown;
        
        private bool _isAttack = false;
        private Transform _attackPos;
        private Scorpion _scorpion;

        private void OnEnable()
        {
            _scorpion = _owner as Scorpion;
        }

        public override void Enter()
        {
            base.Enter();
            
            _isAttack = false;
            int index = Random.Range(0, _scorpion.attackLoadPositionList.Count);
            _attackPos = _scorpion.attackLoadPositionList[index];

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
            AttackLoad attackLoad = PoolingManager.Instnace.Pop(PoolingType.TailSwing_AttackLoad) as AttackLoad;
            attackLoad.transform.position = _attackPos.position;
            
            yield return new WaitForSeconds(_attackLoadTime);

            attackLoad.RealAttack();
            
            yield return new WaitForSeconds(_attackCooldown);

            _isAttack = true;
        }
    }
}
