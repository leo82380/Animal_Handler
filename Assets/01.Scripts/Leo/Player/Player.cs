using System;
using System.Collections;
using Manager.Cinemachine;
using Manager.MouseWinAPI;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private float _mouseSloowDuration = 5f;
    
    private void FixedUpdate()
    {
        transform.position = _playerMove.MousePosition;
    }

    public void MouseSloow()
    {
        MouseWinAPIManager.SetMouseSpeed(1);
        StartCoroutine(MouseSloowCoroutine());
    }

    private IEnumerator MouseSloowCoroutine()
    {
        yield return new WaitForSeconds(_mouseSloowDuration);
        MouseWinAPIManager.ResetMouseSpeed();
    }

    private void OnDestroy()
    {
        MouseWinAPIManager.ResetMouseSpeed();
    }
}