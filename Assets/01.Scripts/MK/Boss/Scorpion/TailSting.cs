using System;
using System.Collections;
using ObjectPooling;
using UnityEngine;

namespace MK.Boss.Pattern
{
    public class TailSting : MonoBehaviour, IPoolable
    {
        # region PoolInfo

        [SerializeField] private LayerMask _whatIsPlayer;
        [SerializeField] private float _duration = 1.5f;
        [field: SerializeField] public PoolingType type { get; set; }
        public GameObject ObjectPrefab { get => gameObject; }
        
        # endregion
        
        public void ResetItem()
        {
            
        }
        
        private void OnEnable()
        {
            StartCoroutine(PushObject());
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (other.TryGetComponent<IDamageable>(out IDamageable health))
                {
                    health.TakeDamage(1);
                }
            }
        }

        private IEnumerator PushObject()
        {
            yield return new WaitForSeconds(_duration);
            PoolingManager.Instnace.Push(this);
        }
    }
}
