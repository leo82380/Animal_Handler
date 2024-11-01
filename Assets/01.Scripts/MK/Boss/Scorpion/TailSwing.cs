using System;
using System.Collections;
using DG.Tweening;
using ObjectPooling;
using UnityEngine;

namespace MK.Boss.Pattern
{
    public class TailSwing : MonoBehaviour, IPoolable
    {
        [field: SerializeField] public PoolingType type { get; set; }
        public GameObject ObjectPrefab { get => gameObject; }
        
        [field: SerializeField] public float Duration { get; set; }
        [field: SerializeField] public float EndDuration { get; set; }

        private Sequence _sequence;
        
        public void ResetItem()
        {
            transform.localScale = new Vector2(0, 3.5f);
        }
        
        private Vector2 Right;
        private Vector2 Left;

        private void Awake()
        {
            Right = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height*0.5f));
            Left = -Right;
        }

        private void OnEnable()
        {
            transform.position = new Vector2(-8.9f, transform.position.y);
        }
        
        public void Attack()
        {
            _sequence = DOTween.Sequence().OnStart(() => { }).Prepend(transform.DOScale(new Vector3(4f, 3.5f, 1), Duration)).
                Append(transform.DOScale(new Vector3(0, 3.5f, 1), EndDuration)).
                OnComplete(() =>
                {
                    PoolingManager.Instnace.Push(this);
                });
        }
    }
}
