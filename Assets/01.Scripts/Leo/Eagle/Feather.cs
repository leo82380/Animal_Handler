using System;
using System.Collections;
using UnityEngine;

public class Feather : MonoBehaviour
{
    public void Shot(Transform target)
    {
        StartCoroutine(ShotCoroutine(target));
    }

    private IEnumerator ShotCoroutine(Transform target)
    {
        float currentTime = 0;
        while (true)
        {
            if (currentTime >= 4) break;
            currentTime += Time.deltaTime;
            transform.right = target.position - transform.position;
            yield return null;
        }
        currentTime = 0;

        while (currentTime < 20)
        {
            currentTime += Time.deltaTime;
            Vector3 dir = transform.right;
            transform.position = Vector3.Lerp(transform.position, transform.position + dir, currentTime);
            yield return null;
            if (Vector3.Distance(transform.position, target.position) < 0.1f) break;
        }
        
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
