using System;
using System.Collections;
using UnityEngine;

public class MouseEventManager : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReaderSO;
    
    private int _clickCount;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Test();
        }
    }

    [ContextMenu("Test")]
    public void Test()
    {
        StartShake();
    }
    private void Awake()
    {
        _inputReaderSO.MouseRightClickEvent += OnMouseRightClick;
        _inputReaderSO.MouseLeftClickEvent += OnMouseLeftClick;
    }

    private void OnDestroy()
    {
        _inputReaderSO.MouseRightClickEvent -= OnMouseRightClick;
        _inputReaderSO.MouseLeftClickEvent -= OnMouseLeftClick;
    }

    private void OnMouseRightClick()
    {
        _clickCount++;
    }

    private void OnMouseLeftClick()
    {
        _clickCount++;
    }

    #region Jack
    public void StartCount(float time)
    {
        StartCoroutine(Count(time));
    }

    private IEnumerator Count(float time)
    {
        float currentTime = 0;
        while (true)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= time)
            {
                //_clickCount = 0;
                break;
            }
            yield return null;
        }
        Debug.Log(_clickCount);
        Debug.Log("Count End");
        _clickCount = 0;
    }
    #endregion

    #region Mouse Shake
    public void StartShake()
    {
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float percent = 0;
        while (percent < 1000)
        {
            var beforePosition = _inputReaderSO.MousePosition;
            yield return null;
            var afterPosition = _inputReaderSO.MousePosition;
            var distance = Vector2.Distance(beforePosition, afterPosition);
            percent += distance;
            Debug.Log(percent);
        }
        
        Debug.Log("Shake End");
    }

    #endregion
}