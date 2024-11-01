using System;
using System.Collections;
using ObjectPooling;
using UnityEngine;

public class SwingHard : MonoBehaviour, IPoolable
{
    [field: SerializeField] public PoolingType type { get; set; }
    public GameObject ObjectPrefab { get => gameObject; }

    [SerializeField] private float _duration = 3f;
    
    public void ResetItem()
    {
        _player = FindObjectOfType<Player>();
        _commandManager = FindObjectOfType<CommandManager>();
        _commandManager.SuccesfullCommandEvent += HandleCommand;
        _commandManager.RandomCommandSetting(5);
        StartCoroutine(Attack());
    }

    private void HandleCommand()
    {
        _isSuccess = true;
    }

    private CommandManager _commandManager;
    private bool _isSuccess = false;
    private Player _player;

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(_duration);
        if (_isSuccess == false)
            _player.GetComponent<Health>().TakeDamage(1);
        
        PoolingManager.Instnace.Push(this);
    }
}
