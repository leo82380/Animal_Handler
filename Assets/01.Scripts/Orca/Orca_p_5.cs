using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orca_p_5 : OState
{
    [SerializeField] private Transform orca_slave_1;
    [SerializeField] private Transform orca_slave_2;
    [SerializeField] private Transform sea;

    public override void Start()
    {
        body = GetComponentInParent<Orca>();
    }

    public override IEnumerator UseSkill()
    {
        if(orca_slave_1.transform.parent != sea)
        {
            orca_slave_1.transform.parent = sea;
            orca_slave_2.transform.parent = sea;
        }



        yield return null;
        body.StateReset();
    }
}
