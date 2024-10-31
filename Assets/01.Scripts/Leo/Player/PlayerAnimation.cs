using System.Collections.Generic;
using Manager.Cinemachine;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private ParticleSystem _breakEffect;
    [SerializeField] private Health _health;
    [SerializeField] private List<Texture2D> _cursorSprites;

    private void Awake()
    {
        _health.OnDie += OnDie;
        _health.OnHealthChange += OnHealthChange;
    }

    #if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _health.TakeDamage(1);
        }
    }
    #endif

    private void OnHealthChange(int obj)
    {
        if (_cursorSprites[obj] == null) return;
        Cursor.SetCursor(_cursorSprites[obj], Vector2.zero, CursorMode.Auto);
        var particle = Instantiate(_breakEffect, transform.position, Quaternion.identity);
        particle.Play();
        CinemachineManager.Instnace.ShakeCamera(3);
    }

    private void OnDie()
    {
        Debug.Log("Die");
    }
}