using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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

        float t = Time.deltaTime, angle, curTime = Time.deltaTime;

        while (t + 2 >= curTime)
        {
            yield return null;
            angle = Mathf.Atan2(pMove.MousePosition.y - orca_slave_1.position.y, 
                pMove.MousePosition.x - orca_slave_1.position.x) * Mathf.Rad2Deg;
            orca_slave_1.rotation = Quaternion.AngleAxis(angle + 170, Vector3.forward);
            Debug.Log(angle + " :: " + orca_slave_1.rotation);
            angle = Mathf.Atan2(pMove.MousePosition.y - orca_slave_2.position.y,
                pMove.MousePosition.x - orca_slave_2.position.x) * Mathf.Rad2Deg;
            orca_slave_2.rotation = Quaternion.AngleAxis(angle + 10, Vector3.forward);
            curTime += Time.deltaTime;
        }

        Debug.Log("fin");

        orca_slave_1.DOMove(orca_slave_1.position + orca_slave_1.right * -1 * 150, Random.Range(2.3f, 3f));
        orca_slave_2.DOMove(orca_slave_2.position + orca_slave_2.right * 150, Random.Range(2.3f, 3f));

        StartCoroutine(body.StateReset());
    }
}
