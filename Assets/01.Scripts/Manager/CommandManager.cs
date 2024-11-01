using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CommandManager : MonoBehaviour
{
    public event Action CorrectCommandEvent;
    public event Action WrongCommandEvent;
    
    [SerializeField] private InputReaderSO _inputReaderSO;
    [SerializeField] private SerializedDictionary<string, Sprite> _commandSample;

    [SerializeField] private List<string> _commandList;
    
    private int _currentCommandIndex = 0;
    private int _isSuccessCount = 0;

    public Transform MouseCommand;

    public List<Image> imageList = new List<Image>();

    private bool _isCorrect = false;
    private bool _isClick = false;

    public event Action SuccesfullCommandEvent;
    
    private void Awake()
    {
        _commandList = new List<string>();
        _currentCommandIndex = 0;
        MouseCommand.gameObject.SetActive(false);
        
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
        if (_isClick) return;
        _isClick = true;
        
        if (!_isCorrect) return;
        if (_commandList[_currentCommandIndex] == "Middle")
        {
            CorrectCommandEvent?.Invoke();
            Debug.Log("Correct at Middle");
            _isSuccessCount++;
            _currentCommandIndex++;
        }
        else
        {
            WrongCommandEvent?.Invoke();
            Debug.Log("Wrong at Middle");
        }
        
        if (_isSuccessCount >= 5)
        {
            MouseCommand.gameObject.SetActive(false);
            SuccesfullCommandEvent?.Invoke();
        }

        _isClick = false;
    }

    private void OnMouseRightClick()
    {
        if (_isClick) return;
        _isClick = true;

        if (!_isCorrect) return;
        if (_commandList[_currentCommandIndex] == "Right")
        {
            CorrectCommandEvent?.Invoke();
            Debug.Log("Correct at Right");
            _isSuccessCount++;
            _currentCommandIndex++;
        }
        else
        {
            WrongCommandEvent?.Invoke();
            Debug.Log("Wrong at Right");
        }
        
        if (_isSuccessCount >= 5)
        {
            MouseCommand.gameObject.SetActive(false);
            SuccesfullCommandEvent?.Invoke();
        }
        
        _isClick = false;
    }

    private void OnMouseLeftClick()
    {
        if (_isClick) return;
        _isClick = true;

        if (!_isCorrect) return;
        if (_commandList[_currentCommandIndex] == "Left")
        {
            CorrectCommandEvent?.Invoke();
            Debug.Log("Correct at Left");
            _isSuccessCount++;
            _currentCommandIndex++;
        }
        else
        {
            WrongCommandEvent?.Invoke();
            Debug.Log("Wrong at Left");
        }

        if (_isSuccessCount >= 5)
        {
            MouseCommand.gameObject.SetActive(false);
            SuccesfullCommandEvent?.Invoke();
        }
        
        _isClick = false;
    }
    
    public void RandomCommandSetting(int count)
    {
        MouseCommand.gameObject.SetActive(true);
        _currentCommandIndex = 0;
        _isSuccessCount = 0;
        _commandList.Clear();
        for (int i = 0; i < count; i++)
        {
            string cmd = RandomCommand();
            Debug.Log(cmd);
            _commandList.Add(cmd);
            imageList[i].sprite = _commandSample[cmd];
        }

        _isCorrect = true;
    }

    private string RandomCommand()
    {
        ICollection<string> keys = _commandSample.Keys;
        string[] keyArray = new string[keys.Count];
        keys.CopyTo(keyArray, 0);
        return keyArray[Random.Range(0, keyArray.Length)];
    }
}