using ObjectPooling;
using UnityEngine;

namespace MK.Boss.Pattern
{
    public class TailSting : MonoBehaviour, IPoolable
    {
        # region PoolInfo
        
        public PoolingType type { get; set; }
        public GameObject ObjectPrefab { get => gameObject; }
        
        # endregion
        
        private Vector2 Right;
        private Vector2 Left;
        private Vector2 Top;
        private Vector2 Bottom;
        public void ResetItem()
        {
            // TODO : Reset
        }

        private void OnEnable()
        {
            SetScreenPosition();
            
            // TODO : 화면 밖으로 안 벗어나게
        }

        private void SetScreenPosition()
        {
            // 화면이 흔들리거나 바뀔수 있으니 이렇게 냅둡
            Right = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height*0.5f));
            Left = -Right;
            Top = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width*0.5f, Screen.height));
            Bottom = -Top;
        }
    }
}
