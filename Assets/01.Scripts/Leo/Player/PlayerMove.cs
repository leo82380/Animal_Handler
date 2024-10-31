using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReaderSO;
    public Vector3 MousePosition { get; set; }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(_inputReaderSO.MousePosition);
        mousePosition.z = 0;
        MousePosition = mousePosition;
    }
}