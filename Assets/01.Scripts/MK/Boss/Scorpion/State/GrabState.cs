using Manager.MouseWinAPI;
using ObjectPooling;
using UnityEngine;

namespace MK.Boss.State
{
    [CreateAssetMenu(menuName = "SO/Boss/Scorpion/Pattern3")]
    public class GrabState : Pattern3State, IPatternProbability
    {
        [field: SerializeField] public int PatternProbability { get; set; }

        private CommandManager _commandManager;
        private bool _isEscape = false;

        private GrapAttackLoad _grap;
        
        public override void Enter()
        {
            _isEscape = false;
            base.Enter();
            
            _commandManager = FindObjectOfType<CommandManager>();
            _commandManager.SuccesfullCommandEvent += HandleCommand;
            _commandManager.RandomCommandSetting(5);

            _grap = PoolingManager.Instnace.Pop(PoolingType.GrapAttackLoad) as GrapAttackLoad;
        }

        private void HandleCommand()
        {
            _isEscape = true;
        }

        public override void UpdateState()
        {
            
            MouseWinAPIManager.SetCursorPosInScreen(Screen.width / 2, Screen.height / 2);
            
            if (_isEscape)
            {
                _grap.Escape();
                _owner.StateMachine.ChangeState(StateEnum.Idle);
            }
        }

        public override void Exit()
        {
            _commandManager.SuccesfullCommandEvent -= HandleCommand;
            _isEscape = false;
            base.Exit();
        }
    }
}
