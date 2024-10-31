using System.Collections;
using System.Collections.Generic;
using ObjectPooling;
using UnityEngine;

public class ToxicFlooring : MonoBehaviour, IPoolable
{
    [field: SerializeField] public PoolingType type { get; set; }
    public GameObject ObjectPrefab { get => gameObject; }
    [SerializeField] private float _duration = 0.7f;

    public void ResetItem()
    {
        
    }

    public Transform saveZone;
    
    private void OnEnable()
    {
        StartCoroutine(PushObject());
    }

    private IEnumerator PushObject()
    {
        yield return new WaitForSeconds(_duration);
        PoolingManager.Instnace.Push(this);
    }
}
