using System.Collections;
using MK.Boss.Pattern;
using ObjectPooling;
using UnityEngine;

namespace MK.Boss
{
    public class AttackLoad : MonoBehaviour, IPoolable
    {
        [SerializeField] private float _duration = 1.5f;

        [field: SerializeField] public PoolingType type { get; set; }
        public GameObject ObjectPrefab { get => gameObject; }
        
        public void ResetItem()
        {
            
        }

        public void RealAttack()
        {
            TailSwing swing = PoolingManager.Instnace.Pop(PoolingType.TailSwing) as TailSwing;
            swing.transform.position = new Vector2(swing.transform.position.x, transform.position.y);
            swing.Attack();
            
            PoolingManager.Instnace.Push(this);
        }
    }
}
