using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State/Orca/Idle")]
public class Orca_Idle : OState
{
    public override void Start()
    {
        body = GetComponentInParent<Orca>();
    }

    public override IEnumerator UseSkill()
    {
        yield return null;
    }
}
