using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.TryGetComponent(out Health health);
        if (health != null) health.TakeDamage(1);
    }
}
