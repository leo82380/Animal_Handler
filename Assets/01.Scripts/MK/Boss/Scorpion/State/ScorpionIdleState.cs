using System.Collections;
using UnityEngine;

namespace  MK.Boss.State
{
    [CreateAssetMenu(menuName = "SO/Boss/Scorpion/Idle")]

    public class ScorpionIdleState : IdleState
    {
        [SerializeField] private float _attackCooldown = 3f;

        private Scorpion _scorpion;
        
        public float patternDelayTime;

        private float _currentDelayTime;
        public PlayerAttackChoicePanel attackChoicePanel;

        private int _patternCnt = 0;
        private bool _isOpenSelect;
        public int patternEvasionCnt;

        private bool check = false;


        private void Awake()
        {
            _scorpion = FindObjectOfType<Scorpion>();
        }

        private void OnEnable()
        {
            _scorpion = _owner as Scorpion;
            attackChoicePanel = FindObjectOfType<PlayerAttackChoicePanel>();
        }
        
        public IEnumerator PlayerAttack()
        {
            Time.timeScale = 1;
            yield return new WaitForSeconds(3);
            attackChoicePanel.Open();
            yield return new WaitForSeconds(0.7f);
            Time.timeScale = 0;
        }
        
        public override void Initialize(StateMachine stateMachine, Agent owner, string animBoolName)
        {
            base.Initialize(stateMachine, owner, animBoolName);
            attackChoicePanel  = FindObjectOfType<PlayerAttackChoicePanel>();
            attackChoicePanel.gameObject.SetActive(false);
            _patternCnt = 0;
            _scorpion = _owner as Scorpion;
            _isOpenSelect = false;
        }
        
        public override void Enter()
        {
            base.Enter();

            check = false;

            if (_patternCnt >= patternEvasionCnt)
            {
                _isOpenSelect = true;
                _patternCnt = 0;
                _owner.mainVisual.SetActive(true);
                attackChoicePanel.Open();
            }
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if (!_isOpenSelect)
            {
                _currentDelayTime += Time.deltaTime;
                if (_currentDelayTime >= patternDelayTime)
                {
                    _stateMachine.ChangeState(_scorpion.RandomPattern());
                    _currentDelayTime = 0;
                }
            }
            if (!attackChoicePanel.gameObject.activeSelf)
            {
                _isOpenSelect = false;
            }
        }

        public override void Exit()
        {
            _patternCnt++;
            base.Exit();
        }

        private IEnumerator NextAttack()
        {
            yield return new WaitForSeconds(_attackCooldown);
            _owner.StateMachine.ChangeState(_scorpion.RandomPattern());
        }
    }
}
