using UnityEngine;

namespace MKDir
{
    public class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;

        public static T Instnace
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));
                    if (_instance == null)
                    {
                        SetupInstnace();
                    }
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            RemoveDuplicates();
        }

        private void OnDisable()
        {
            _instance = null;
        }

        private static void SetupInstnace()
        {
            _instance = (T)FindObjectOfType(typeof(T));
            if (_instance == null)
            {
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                _instance = obj.AddComponent<T>();
                DontDestroyOnLoad(obj);
            }
        }

        private void RemoveDuplicates()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
