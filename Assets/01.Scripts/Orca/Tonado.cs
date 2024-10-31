using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;
using DG.Tweening;

public class Tonado : MonoBehaviour, IPoolable
{
    [field:SerializeField] public PoolingType type { get; set; }

    public GameObject ObjectPrefab => gameObject;

    public IEnumerator Duration(float _time)
    {
        yield return new WaitForSeconds(_time);

        transform.DOScaleY(0, 1.8f).OnComplete(() => PoolingManager.Instnace.Push(this, true));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.TryGetComponent(out Health health);
        if (health != null) health.TakeDamage(1);
    }

    public void ResetItem()
    {
    }
}
