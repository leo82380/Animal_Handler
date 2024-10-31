using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager.Cinemachine;
using System;
using Manager.MouseWinAPI;

[CreateAssetMenu(menuName = "State/Bear/Pattern5")]
public class BearPattern5State : Pattern5State
{
    public CinemachineManager cinemachineManager;
    public float patternTime;
    [SerializeField] private float _clickCnt;
    private bool isShake;
    private Health playerHealth;

    public override void Enter()
    {
        base.Enter();
        if(cinemachineManager == null)
        {
            cinemachineManager = FindObjectOfType<CinemachineManager>();
        }
        
        MouseEventManager.Instnace.StartCount(patternTime);
        MouseEventManager.Instnace.OnClick += ClickHandleEvent;
        

    }
    
    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
        {
            _stateMachine.ChangeState(StateEnum.Idle);
        }
        else
        {
            MouseWinAPIManager.SetCursorPosInScreen(1920 / 2, 1080 / 2);

        }
        //_stateMachine.ChangeState(StateEnum.Idle);
        //else
        //{
        //    MouseWinAPIManager.SetCursorPosInScreen(1920 / 2, 1080 / 2);
        //}

        if (isShake)
        {
            cinemachineManager.ShakeCamera(2f);
            isShake = false;
        }
        

    }
    public override void Exit()
    {
        MouseEventManager.Instnace.OnClick -= ClickHandleEvent;
        MouseEventManager.Instnace.StopCount();
        base.Exit();
    }

    private void ClickHandleEvent(float obj,float time)
    {
        if(obj >= _clickCnt)
        {
            _endTriggerCalled = true;
        }
        else if (time > patternTime)
        {
            MouseEventManager.Instnace.StopCount();
            _endTriggerCalled = true;
        }
    }

    public override void AanimationEnd()
    {

        isShake = true;
    }
}
