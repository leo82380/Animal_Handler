using System;
using System.Collections;
using ObjectPooling;
using UnityEngine;

namespace MK.Boss.Pattern
{
    public class TailSwing : MonoBehaviour, IPoolable
    {
        [field: SerializeField] public PoolingType type { get; set; }
        public GameObject ObjectPrefab { get => gameObject; }
        
        [field: SerializeField] public float Duration { get; set; }
        
        public void ResetItem()
        {
            
        }
        
        // TODO : 콜라이더로 공격
        // TODO : Lerp

        private void OnEnable()
        {
            StartCoroutine(PushObject());
        }
        
        private IEnumerator PushObject()
        {
            yield return new WaitForSeconds(Duration);
            PoolingManager.Instnace.Push(this);
        }
    }
}
