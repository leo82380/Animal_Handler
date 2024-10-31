using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MK.Boss
{
    public class Scorpion : Agent
    {
        [SerializeField] private PoolingManager _poolManager;
        
        public StateEnum RandomPattern()
        {
            int randomMax = 0;
            int cumulative = 0;
            int randomValue = 0;

            for (int i = 0; i < _states.Count; ++i)
            {
                PatternState pattern = _states[i] as PatternState;
                IPatternProbability probability = pattern as IPatternProbability;
                randomMax += probability.PatternProbability;
            }
            
            randomValue = Random.Range(0, randomMax);

            for (int i = 0; i < _states.Count; ++i)
            {
                PatternState pattern = _states[i] as PatternState;
                IPatternProbability probability = pattern as IPatternProbability;

                cumulative += probability.PatternProbability;
                if (randomValue <= cumulative)
                {
                    return pattern.StateEnum;
                }
            }
            
            return StateEnum.Idle;
        }
    }
}
