using System;
using Manager.Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CinemachineManager.Instnace.ShakeCamera(100f);
        }
        transform.position = _playerMove.MousePosition;
    }
}