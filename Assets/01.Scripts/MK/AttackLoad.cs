using System;
using System.Collections;
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

        private void OnEnable()
        {
            StartCoroutine(PushObject());
        }

        private IEnumerator PushObject()
        {
            yield return new WaitForSeconds(_duration);
            PoolingManager.Instnace.Push(this);
        }
    }
}
