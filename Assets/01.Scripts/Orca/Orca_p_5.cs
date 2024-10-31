using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orca_p_5 : OState
{
    [SerializeField] private Transform orca_slave_1;
    [SerializeField] private Transform orca_slave_2;
    [SerializeField] private Transform sea;
    [SerializeField] private PlayerMove pMove;

    public override void Start()
    {
        body = GetComponentInParent<Orca>();
    }

    public override IEnumerator UseSkill()
    {
        if(orca_slave_1.parent != sea)
        {
            orca_slave_1.parent = sea;
            orca_slave_2.parent = sea;
        }

        orca_slave_1.localPosition = new Vector3(1400, Random.Range(0, 1150));
        orca_slave_1.rotation = Quaternion.Euler(0, 0, 90);
        orca_slave_1.localScale = new Vector3(-1, 1, 1);
        orca_slave_2.localPosition = new Vector3(-1400, Random.Range(0, 1150));
        orca_slave_2.localScale = Vector3.one;

        orca_slave_1.gameObject.SetActive(true);
        orca_slave_2.gameObject.SetActive(true);

        float t = Time.deltaTime, angle;

        while (t + 2 >= Time.deltaTime)
        {
            yield return null;
            angle = Mathf.Atan2(pMove.MousePosition.y - orca_slave_1.position.y, 
                pMove.MousePosition.x - orca_slave_1.position.x) * Mathf.Rad2Deg;
            orca_slave_1.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            angle = Mathf.Atan2(pMove.MousePosition.y - orca_slave_2.position.y,
                pMove.MousePosition.x - orca_slave_2.position.x) * Mathf.Rad2Deg;
            orca_slave_2.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            Debug.Log(pMove.MousePosition);
        }

        Debug.Log("fin");
        

        yield return null;
        body.StateReset();
    }
}
