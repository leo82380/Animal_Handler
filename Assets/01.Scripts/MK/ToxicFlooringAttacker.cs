using System;
using System.Collections;
using System.Collections.Generic;
using Manager.MouseWinAPI;
using Unity.VisualScripting;
using UnityEngine;

public class ToxicFlooringAttacker : MonoBehaviour
{
    private Player _player;
    private bool _isSave = false;
    private bool _isDam = false;

    private void Awake()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (_isSave == false)
        {
            Debug.Log("맞는 중");
            
            if(_player.TryGetComponent<IDamageable>(out IDamageable health))
            {
                // TODO : 여기 도트 딜
                
                MouseWinAPIManager.SetMouseSpeed(1);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 여기는 안전
            _isSave = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isSave = false;
        }
    }
}
