using UnityEngine;

namespace MK.Boss.State
{
    public class SwingHardState : Pattern6State, IPatternProbability
    {
        [field: SerializeField] public int PatternProbability { get; set; }
        
        public override void Enter()
        {
            base.Enter();
        }
        
        public override void UpdateState()
        {
            base.UpdateState();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
