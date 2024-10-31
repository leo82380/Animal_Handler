using System;
using Manager.Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    
    private void FixedUpdate()
    {
        transform.position = _playerMove.MousePosition;
    }
}