using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Orca_p_4 : OState
{
    [SerializeField] private Transform sea;
    [SerializeField] private Image orca;
    public override void Start()
    {
        body = GetComponentInParent<Orca>();
    }
    public override IEnumerator UseSkill()
    {
        if(!body.filedIsWater)
        {
            body.filedIsWater = true;
            sea.DOLocalMoveY(-560, 5).OnComplete(() => orca.transform.parent = sea);
        }

        yield return new WaitForSeconds(1f);
        StartCoroutine(body.StateReset());
    }
}
