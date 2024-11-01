using System;
using TMPro;
using UnityEngine;

public class AnimalGet : MonoBehaviour
{
    public Action OnGetAnimal;
    [SerializeField] private TextMeshProUGUI _percentageText;
    
    private int _percentage;

    public int Percentage
    {
        get => _percentage;
        set
        {
            if (value >= 100)
            {
                OnGetAnimal?.Invoke();
            }
            _percentage = value;
            _percentageText.text = $"포획률: {_percentage}%";
        }
    }

    public void Init()
    {
        _percentageText.text = $"포획률: {_percentage}%";
    }
}
