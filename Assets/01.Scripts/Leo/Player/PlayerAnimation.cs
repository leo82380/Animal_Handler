using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
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
    }

    private void OnDie()
    {
        
    }
}