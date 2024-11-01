using System.Collections;
using ObjectPooling;
using UnityEngine;

namespace MK.Boss.Pattern
{
    public class ToxicFlooringLoad : MonoBehaviour, IPoolable
    {
        [SerializeField] private float _duration = 1.5f;

        [field: SerializeField] public PoolingType type { get; set; }
        public GameObject ObjectPrefab { get => gameObject; }

        [SerializeField] private Transform _flooring;
        [SerializeField] private Transform _saveJone;
        
        private Vector2 Right;
        private Vector2 Left;
        private Vector2 Top;
        private Vector2 Bottom;
        
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
        
        public void ResetItem()
        {

        }
        public void RandomAttackPostion()
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
            ToxicFlooring flooring  = PoolingManager.Instnace.Pop(PoolingType.ToxicFlooring) as ToxicFlooring;
            flooring.saveZone.position = _saveJone.position;
            
            PoolingManager.Instnace.Push(this);
        }
    }
}
