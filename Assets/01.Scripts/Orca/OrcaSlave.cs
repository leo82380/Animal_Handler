using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcaSlave : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Jump"))
        {
            Debug.Log(gameObject.name[11]);
            if (gameObject.name[11] == collision.gameObject.name[14])
                collision.gameObject.SetActive(false);
        }
    }
}
