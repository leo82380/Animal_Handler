
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[CreateAssetMenu(menuName = "State/Bear/Pattern2")]
public class BearPattern2State : Pattern2State
{
    public FullScreenPassRendererFeature fullScrean;
    public float patternTime;
    public Material mat;

    public override void Enter()
    {
        base.Enter();
        MouseEventManager.Instnace.StartShake(patternTime);
        MouseEventManager.Instnace.OnShake += ShakeHandleEvent;
        mat.SetFloat("_Power", 0);
        fullScrean.SetActive(true);

    }
    public override void UpdateState()
    {
        base.UpdateState();
        if (_endTriggerCalled)
            _stateMachine.ChangeState(StateEnum.Idle);


    }
    public override void Exit()
    {
        fullScrean.SetActive(false);
        MouseEventManager.Instnace.OnShake -= ShakeHandleEvent;
        base.Exit();
    }

    private void ShakeHandleEvent(float obj,float time)
    {
        if(mat != null && mat.GetFloat("_Power") <= 1)
        {
            float a = mat.GetFloat("_Power");
            a += obj * 0.0000001f;
            mat.SetFloat("_Power",Mathf.Clamp( a,0,1));
            if(a >= 1)
            {
                MouseEventManager.Instnace.StopShake();
                _endTriggerCalled = true;
            }
            else if(time > patternTime)
            {
                MouseEventManager.Instnace.StopShake();
                fullScrean.SetActive(false);
                PlayerManager.Instnace.PlayerHealth.TakeDamage(1);
                _endTriggerCalled = true;
            }
        }

    }
}
