using System;
using UnityEngine;

namespace ObjectPooling
{
    [CreateAssetMenu(menuName = "SO/Pool/PoolItem")]
    public class PoolingItemSO : ScriptableObject
    {
        public string enumName;
        public string poolingName;
        public string description;
        public int poolCount;
        public GameObject prefabObject;

        public IPoolable prefab = null;
        
        private void OnValidate()
        {
            CheckInterface();
        }

        private void OnEnable()
        {
            CheckInterface();
        }

        private void CheckInterface()
        {
            if (prefabObject != null)
            {
                if (prefabObject.TryGetComponent(out IPoolable poolable))
                {
                    prefab = poolable;
                    if (enumName != prefab.type.ToString())
                    {
                        prefab = null;
                        prefabObject = null;
                        Debug.LogWarning("Type missMatch!");
                    }
                    
                }
                else
                {
                    prefabObject = null;
                    Debug.LogWarning("Not Poolable");
                }
               
            }
        }
    }
}
