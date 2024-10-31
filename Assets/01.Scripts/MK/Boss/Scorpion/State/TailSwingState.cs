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
        [SerializeField] private float _attackSpeed = 5f;
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
        
        private IEnumerator Attack()
        {
            AttackLoad attackLoad = PoolingManager.Instnace.Pop(PoolingType.TailSwing_AttackLoad) as AttackLoad;
            attackLoad.transform.position = _attackPos.position;
            
            yield return new WaitForSeconds(_attackCooldown);
            
            // TODO : Pooling으로 공격 프리팹 생성
            // TODO : 닷트윈 공격 Lerp
            // TODO : 닷트윈 시퀸스 사용해서 트윈 끝나고 isAttack = true; 로 Idle 스테이트로
        }
    }
}
