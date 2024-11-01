using System;
using System.Collections;
using Manager.MouseWinAPI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private float _mouseSloowDuration = 5f;
    private Health _health;
    
    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.OnDie += OnDie;
    }

    private void OnDisable()
    {
        _health.OnDie -= OnDie;
    }

    private void OnDie()
    {
        SceneManager.LoadScene(0);
    }

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