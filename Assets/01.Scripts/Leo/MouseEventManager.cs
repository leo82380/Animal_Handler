using System;
using System.Collections;
using MKDir;
using UnityEngine;

public class MouseEventManager : MonoSingleton<MouseEventManager>
{
    public Action<float,float> OnShake;
    public Action<float,float> OnClick;
    [SerializeField] private InputReaderSO _inputReaderSO;
    
    private int _clickCount;

    private Coroutine _stopShakeCorotine;
    private Coroutine _stopClickCorotine;

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Test();
    //    }
    //}

    //[ContextMenu("Test")]
    //public void Test()
    //{
    //    StartShake();
    //}
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
        _stopClickCorotine =  StartCoroutine( Count(time));
    }

    //private IEnumerator Count(float time)
    //{
    //    float currentTime = 0;
    //    while (true)
    //    {
    //        currentTime += Time.deltaTime;
    //        if (currentTime >= time)
    //        {
    //            //_clickCount = 0;
    //            break;
    //        }
    //        yield return null;
    //    }
    //    Debug.Log(_clickCount);
    //    Debug.Log("Count End");
    //    _clickCount = 0;
    //}

    private IEnumerator Count(float time)
    {
        float currentTime = 0;
        while (currentTime < time)
        {
            currentTime += Time.deltaTime;
            
            yield return null;
            OnClick?.Invoke(_clickCount, currentTime);
        }
        Debug.Log(_clickCount);
        Debug.Log("Count End");
        _clickCount = 0;
    }

    public void StopCount()
    {
        StopCoroutine(_stopClickCorotine);
    }

     
    #endregion

    #region Mouse Shake
    public void StartShake(float time)
    {
        _stopClickCorotine = StartCoroutine(Shake(time));
    }

    public void StopShake()
    {
        if (_stopClickCorotine != null)
        {
            StopCoroutine(_stopClickCorotine);
        }
    }

    private IEnumerator Shake(float time)
    {
        float percent = 0;
        float currnetTIme = 0;
        while (percent < 100000 && time >= currnetTIme)
        {
            currnetTIme += Time.deltaTime;
            var beforePosition = _inputReaderSO.MousePosition;
            yield return null;
            var afterPosition = _inputReaderSO.MousePosition;
            var distance = Vector2.Distance(beforePosition, afterPosition);
            percent += distance;
            OnShake?.Invoke(percent, currnetTIme);
        }
        
        Debug.Log("Shake End");
    }

    #endregion
}