using System.Collections.Generic;
using Manager.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private ParticleSystem _breakEffect;
    [SerializeField] private Health _health;
    [SerializeField] private List<Texture2D> _cursorSprites;

    public GameObject TileCanvas;

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

    private void OnDestroy()
    {
        _health.OnHealthChange -= OnHealthChange;
    }

    private void OnHealthChange(int obj)
    {
        if (obj <= 0) return;
        Cursor.SetCursor(_cursorSprites[obj], Vector2.zero, CursorMode.Auto);
        var particle = Instantiate(_breakEffect, transform.position, Quaternion.identity);
        particle.Play();
        CinemachineManager.Instnace.ShakeCamera(3);
    }

    private void OnDie()
    {
        TileCanvas.SetActive(true);
    }
}