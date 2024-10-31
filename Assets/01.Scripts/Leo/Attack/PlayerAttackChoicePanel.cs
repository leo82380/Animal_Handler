using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerAttackChoicePanel : MonoBehaviour, IWindow
{
    [SerializeField] private AnimalGet _animalGet;
    [SerializeField] private List<PlayerAttackChoiceItem> _playerAttackChoiceItems;
    
    [ContextMenu("Open")]
    public void Open()
    {
        _animalGet.Init();
        foreach (var playerAttackChoiceItem in _playerAttackChoiceItems)
        {
            playerAttackChoiceItem.SetData();
            playerAttackChoiceItem.AttackChoiceSO.SetRandomGenerate();
        }
        gameObject.SetActive(true);
        transform.DOScaleY(1, 0.5f);
    }

    [ContextMenu("Close")]
    public void Close()
    {
        transform.DOScaleY(0, 0.5f).OnComplete(() => gameObject.SetActive(false));
    }
}