using System.Collections.Generic;
using UnityEngine;

namespace ObjectPooling
{
    public class Pool
    {
        private Stack<IPoolable> _pool = new Stack<IPoolable>();
        private IPoolable _prefab;
        private Transform _parent;
        
        private PoolingType _type;

        public Pool(IPoolable prefab, PoolingType type, Transform parent, int count)
        {
            _prefab = prefab;
            _type = type;
            _parent = parent;

            for (int i = 0; i < count; i++)
            {
                GameObject obj = GameObject.Instantiate(_prefab.ObjectPrefab, _parent);
                
                obj.gameObject.name = _type.ToString();
                obj.gameObject.SetActive(false);
                IPoolable item = obj.GetComponent<IPoolable>();
                item.type = _type;
                _pool.Push(item);
            }
        }

        public IPoolable Pop()
        {
            IPoolable item;
            if (_pool.Count <= 0)
            {
                // 부족하면 새로 보충하는 부분
                GameObject obj = GameObject.Instantiate(_prefab.ObjectPrefab, _parent);
                obj.gameObject.name = _type.ToString();
                item = obj.GetComponent<IPoolable>();
                item.type = _type;
            }
            else
            {
                item = _pool.Pop();
                item.ObjectPrefab.SetActive(true);
            }

            return item;
        }
        
        public void Push(IPoolable obj)
        {
            obj.ObjectPrefab.SetActive(false);
            _pool.Push(obj);
        }
    }
}

