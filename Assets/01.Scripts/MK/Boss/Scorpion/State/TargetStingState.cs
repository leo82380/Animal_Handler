using UnityEngine;

namespace MK.Boss.State
{
    public class TargetStingState : Pattern4State, IPatternProbability
    {
        [field: SerializeField] public int PatternProbability { get; set; }
        
        [SerializeField] private int _attackCount;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private float _radius;
        
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
