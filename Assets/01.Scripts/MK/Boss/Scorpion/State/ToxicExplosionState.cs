using UnityEngine;

namespace MK.Boss.State
{
    public class ToxicExplosionState : Pattern5State, IPatternProbability
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

