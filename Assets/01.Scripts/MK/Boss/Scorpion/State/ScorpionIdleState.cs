using System.Collections;
using UnityEngine;

namespace  MK.Boss.State
{
    [CreateAssetMenu(menuName = "SO/Boss/Scorpion/Idle")]

    public class ScorpionIdleState : IdleState
    {
        [SerializeField] private float _attackCooldown = 3f;

        private Scorpion _scorpion;

        private void OnEnable()
        {
            _scorpion = _owner as Scorpion;
        }

        public override void Enter()
        {
            base.Enter();
            _owner.StartCoroutine(NextAttack());
        }
        
        private IEnumerator NextAttack()
        {
            yield return new WaitForSeconds(_attackCooldown);
            _owner.StateMachine.ChangeState(_scorpion.RandomPattern());
        }
    }
}
