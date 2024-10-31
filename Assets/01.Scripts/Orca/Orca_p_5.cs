using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orca_p_5 : OState
{
    public override void Awake()
    {
        body = GetComponentInParent<Orca>();
    }
    public override IEnumerator UseSkill()
    {
        yield return null;
        body.StateReset();
    }
}
