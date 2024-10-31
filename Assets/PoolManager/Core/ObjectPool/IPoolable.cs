using UnityEngine;

namespace ObjectPooling
{
    public interface IPoolable
    {
        [field: SerializeField] public PoolingType type { get; set; }
        public GameObject ObjectPrefab { get; }
        
        public void ResetItem();
    }
}