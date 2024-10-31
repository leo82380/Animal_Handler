using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;

public class Orca_p_3 : OState
{
    public override void Awake()
    {
        body = GetComponentInParent<Orca>();
    }
    public override IEnumerator UseSkill()
    {
        yield return null;
        GameObject obj =  PoolingManager.Instnace.Pop(PoolingType.Water_Bubble).ObjectPrefab;
        Instantiate(obj);

        body.StateReset();
    }
}
