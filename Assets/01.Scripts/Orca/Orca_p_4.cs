using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Orca_p_4 : OState
{
    [SerializeField] private Transform sea;
    public override void Start()
    {
        body = GetComponentInParent<Orca>();
    }
    public override IEnumerator UseSkill()
    {
        if(!body.filedIsWater)
        {
            body.filedIsWater = true;
            sea.DOLocalMoveY(-540, 5);
        }

        yield return null;
        body.StateReset();
    }
}
