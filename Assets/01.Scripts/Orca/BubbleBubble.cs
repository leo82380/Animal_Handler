using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;

public class BubbleBubble : MonoBehaviour, IPoolable
{
    [field:SerializeField] public PoolingType type { get; set; }

    public GameObject ObjectPrefab => gameObject;

    public void ResetItem()
    {
    }
}
