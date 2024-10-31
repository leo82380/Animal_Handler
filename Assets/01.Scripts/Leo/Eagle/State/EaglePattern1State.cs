using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Eagle/Pattern1")]
public class EaglePattern1State : Pattern1State
{
    public Feather feather;
    public override void Enter()
    {
        base.Enter();
        _owner.StartCoroutine(UseSkill());
    }

    private IEnumerator UseSkill()
    {
        float width = Screen.width;
        float height = Screen.height;
        for (int i = 0; i < 10; i++)
        {
            Vector3 randomPos = new Vector3(Random.Range(0, width), Random.Range(0, height), 0);
            Vector3 targetPos = Camera.main.ScreenToWorldPoint(randomPos);
            targetPos.z = 0;
            Feather f = Instantiate(feather, targetPos, Quaternion.identity);
            
            f.Shot(PlayerManager.Instnace.PlayerTransform);
        }
        
        yield return new WaitForSeconds(1f);
        _stateMachine.ChangeState(StateEnum.Idle);
    }
}
