using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttackChoicePanel : MonoBehaviour, IWindow
{
    [SerializeField] internal AnimalGet _animalGet;
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
            playerAttackChoiceItem.AttackChoiceSO.SetRandomGenerate();
            playerAttackChoiceItem.SetData();
        }

        gameObject.SetActive(true);
        transform.DOScaleY(1, 0.5f);
    }

    [ContextMenu("Close")]
    public void Close()
    {
        transform.DOScaleY(0, 0.5f).OnComplete(() => gameObject.SetActive(false));
        Orca or = FindObjectOfType<Orca>();
        if (or != null) or.Start();
        //_animalGet.Percentage = 100;
    }
}