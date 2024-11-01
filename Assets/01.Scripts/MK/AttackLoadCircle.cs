using System;
using System.Collections;
using ObjectPooling;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MK.Boss.Pattern
{
    public class AttackLoadCircle : MonoBehaviour, IPoolable
    {
        [field: SerializeField] public PoolingType type { get; set; }
        public GameObject ObjectPrefab { get => gameObject; }
        public void ResetItem()
        {
            
        }
        
        private Vector2 Right;
        private Vector2 Left;
        private Vector2 Top;
        private Vector2 Bottom;
        
        [field: SerializeField] public float Duration { get; set; }

        private void Awake()
        {
            SetScreenPosition();
        }
        
        private void SetScreenPosition()
        {
            // 화면이 흔들리거나 바뀔수 있으니 이렇게 냅둡
            Right = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height*0.5f));
            Left = -Right;
            Top = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width*0.5f, Screen.height));
            Bottom = -Top;
        }
        
        public void RadiusAndPositionAttack(float radius = 1f, bool isRandom = false)
        {
            transform.localScale = new Vector3(radius, radius, 1);

            if (isRandom == false) return;
            
            RandomAttackPostion();
        }

        private void RandomAttackPostion()
        {
            int x = Mathf.Clamp((int)Random.Range(Left.x, Right.x), 
                (int)(Left.x + transform.localScale.x / 2),
                (int)(Right.x - transform.localScale.x / 2));
            int y = Mathf.Clamp((int)Random.Range(Top.y, Bottom.y), 
                (int)(Top.y - transform.localScale.y / 2),
                (int)(Bottom.y + transform.localScale.y / 2));
            
            transform.position = new Vector3(x, y, 0);
        }

        public void RealAttack()
        {
            TailSting sting  = PoolingManager.Instnace.Pop(PoolingType.TailSting) as TailSting;
            sting.transform.localScale = transform.localScale;
            sting.transform.position = transform.position;
            
            PoolingManager.Instnace.Push(this);
        }
    }
}
