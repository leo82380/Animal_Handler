using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcaSlave : MonoBehaviour
{
    internal Collider2D target;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (target == collision)
        {
            Debug.Log(target.gameObject.name + " / " + collision.gameObject.name);
            collision.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.TryGetComponent(out Health health);
        if (health != null) health.TakeDamage(1);
    }
}
