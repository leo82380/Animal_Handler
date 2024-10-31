using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Orca_p_2 : OState
{
    [SerializeField] private Transform wave;
    [SerializeField] private bool leftStart;

    public override void Start()
    {
        body = GetComponentInParent<Orca>();
        wave.gameObject.SetActive(false);
    }
    public override IEnumerator UseSkill()
    {
        leftStart = Random.Range(0, 2) == 0;

        wave.localPosition = new Vector2(leftStart ? -1350 : 1350, 1480);
        wave.localScale = new Vector3(leftStart ? 1 : -1, 1, 1);
        wave.gameObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        wave.DOLocalMove(new Vector3(leftStart ? 1350 : -1350, 1100), 1.8f);


        StartCoroutine(body.StateReset());
    }
}
