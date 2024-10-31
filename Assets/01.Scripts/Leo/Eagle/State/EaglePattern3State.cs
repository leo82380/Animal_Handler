using System.Collections;
using System.Collections.Generic;
using Manager.MouseWinAPI;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Eagle/Pattern3")]
public class EaglePattern3State : Pattern3State
{
    public override void Enter()
    {
        base.Enter();
        _owner.StartCoroutine(Wind());
    }

    private IEnumerator Wind()
    {
        float time = 0;
        while (time < 10)
        {
            MouseWinAPIManager.SetCursorPosInScreen(Random.Range(0, Screen.width), 0);
            time += Time.deltaTime;
            yield return null;
        }
        _stateMachine.ChangeState(StateEnum.Idle);
    }
}
