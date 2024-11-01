using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttackChoicePanel : MonoBehaviour, IWindow
{
    [SerializeField] private AnimalGet _animalGet;
    [SerializeField] private List<PlayerAttackChoiceItem> _playerAttackChoiceItems;
    [SerializeField] private int nextStage;

    private void OnEnable()
    {
        _animalGet.OnGetAnimal += StageHandleEvent;
    }

    private void OnDisable()
    {
        _animalGet.OnGetAnimal -= StageHandleEvent;
    }

    private void StageHandleEvent()
    {
        SceneManager.LoadScene(nextStage);
    }

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
        //_animalGet.Percentage = 100;
    }
}