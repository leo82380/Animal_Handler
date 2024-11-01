using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDL : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
