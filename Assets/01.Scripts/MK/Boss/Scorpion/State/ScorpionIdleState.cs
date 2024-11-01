using System.Collections;
using UnityEngine;

namespace  MK.Boss.State
{
    [CreateAssetMenu(menuName = "SO/Boss/Scorpion/Idle")]

    public class ScorpionIdleState : IdleState
    {
        [SerializeField] private float _attackCooldown = 3f;

        private Scorpion _scorpion;
        public PlayerAttackChoicePanel ap;
        
        public float patternDelayTime;

        private float _currentDelayTime;
        public PlayerAttackChoicePanel attackChoicePanel;

        private int _patternCnt = 0;
        private bool _isOpenSelect;
        public int patternEvasionCnt;

        private void OnEnable()
        {
            _scorpion = _owner as Scorpion;
            ap = FindObjectOfType<PlayerAttackChoicePanel>();
        }
        
        public IEnumerator PlayerAttack()
        {
            Time.timeScale = 1;
            yield return new WaitForSeconds(3);
            ap.Open();
            yield return new WaitForSeconds(0.7f);
            Time.timeScale = 0;
        }
        
        public override void Initialize(StateMachine stateMachine, Agent owner, string animBoolName)
        {
            base.Initialize(stateMachine, owner, animBoolName);
            attackChoicePanel  = FindObjectOfType<PlayerAttackChoicePanel>();
            attackChoicePanel.gameObject.SetActive(false);
            _patternCnt = 0;
            _isOpenSelect = false;
        }

        public override void Enter()
        {
            base.Enter();
            _patternCnt++;

            if (_patternCnt >= 10)
            {
                _owner.StartCoroutine(PlayerAttack());
                _patternCnt = 0;
            }
            else
            {
                _owner.StartCoroutine(NextAttack());
            }
            
            if(_patternCnt >= 10)
            {
                _isOpenSelect = true;
                _patternCnt = 0;
                attackChoicePanel.Open();
            }
        }
        
        public override void UpdateState()
        {
            base.UpdateState();
            if(!attackChoicePanel.gameObject.activeSelf)
            {
                _isOpenSelect = false;
            }
        }
        
        private IEnumerator NextAttack()
        {
            yield return new WaitForSeconds(_attackCooldown);
            _owner.StateMachine.ChangeState(_scorpion.RandomPattern());
        }
    }
}
