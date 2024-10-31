using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CommandManager : MonoBehaviour
{
    public event Action CorrectCommandEvent;
    public event Action WrongCommandEvent;
    
    [SerializeField] private InputReaderSO _inputReaderSO;
    [SerializeField] private SerializedDictionary<string, Sprite> _commandSample;

    [SerializeField] private List<string> _commandList;
    
    private int _currentCommandIndex = 0;
    
    
    
    private void Awake()
    {
        _commandList = new List<string>();
        _currentCommandIndex = 0;
        _inputReaderSO.MouseLeftClickEvent += OnMouseLeftClick;
        _inputReaderSO.MouseRightClickEvent += OnMouseRightClick;
        _inputReaderSO.MouseMiddleClickEvent += OnMouseMiddleClick;
    }
    
    private void OnDestroy()
    {
        _inputReaderSO.MouseLeftClickEvent -= OnMouseLeftClick;
        _inputReaderSO.MouseRightClickEvent -= OnMouseRightClick;
        _inputReaderSO.MouseMiddleClickEvent -= OnMouseMiddleClick;
    }

    private void OnMouseMiddleClick()
    {
        if (_commandList[_currentCommandIndex] == "Middle")
        {
            CorrectCommandEvent?.Invoke();
            Debug.Log("Correct at Middle");
        }
        else
        {
            WrongCommandEvent?.Invoke();
            Debug.Log("Wrong at Middle");
        }

        _currentCommandIndex++;
    }

    private void OnMouseRightClick()
    {
        if (_commandList[_currentCommandIndex] == "Right")
        {
            CorrectCommandEvent?.Invoke();
            Debug.Log("Correct at Right");
        }
        else
        {
            WrongCommandEvent?.Invoke();
            Debug.Log("Wrong at Right");
        }
        
        _currentCommandIndex++;
    }

    private void OnMouseLeftClick()
    {
        if (_commandList[_currentCommandIndex] == "Left")
        {
            CorrectCommandEvent?.Invoke();
            Debug.Log("Correct at Left");
        }
        else
        {
            WrongCommandEvent?.Invoke();
            Debug.Log("Wrong at Left");
        }
        
        _currentCommandIndex++;
    }
    
    private void RandomCommandSetting(int count)
    {
        _commandList.Clear();
        for (int i = 0; i < count; i++)
        {
            _commandList.Add(RandomCommand());
        }
    }

    private string RandomCommand()
    {
        ICollection<string> keys = _commandSample.Keys;
        string[] keyArray = new string[keys.Count];
        keys.CopyTo(keyArray, 0);
        return keyArray[Random.Range(0, keyArray.Length)];
    }
}