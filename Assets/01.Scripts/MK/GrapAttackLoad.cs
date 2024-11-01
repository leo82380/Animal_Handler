using System.Collections;
using ObjectPooling;
using UnityEngine;

public class GrapAttackLoad : MonoBehaviour, IPoolable
{
    [field: SerializeField] public PoolingType type { get; set; }
    public GameObject ObjectPrefab { get => gameObject; }
    public void ResetItem()
    {
        
    }

    public void Escape()
    {
        PoolingManager.Instnace.Push(this);
    }
}
