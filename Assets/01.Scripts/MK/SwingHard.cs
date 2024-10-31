using ObjectPooling;
using UnityEngine;

public class SwingHard : MonoBehaviour, IPoolable
{
    [field: SerializeField] public PoolingType type { get; set; }
    public GameObject ObjectPrefab { get => gameObject; }
    public void ResetItem()
    {
        
    }
}
