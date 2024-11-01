using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailSwingAttacker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<IDamageable>(out IDamageable health))
            {
                health.TakeDamage(1);
            }
        }
    }
}
