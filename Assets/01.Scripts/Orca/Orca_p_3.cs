using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;
using DG.Tweening;

public class Orca_p_3 : OState
{
    [SerializeField] private Transform sea;
    public override void Start()
    {
        body = GetComponentInParent<Orca>();
    }

    public override IEnumerator UseSkill()
    {
        for (int i = 0; i < (body.level == 4 ? 2 : 1); i++)
        {
            Tonado obj = PoolingManager.Instnace.Pop(PoolingType.Water_Tonado).
            ObjectPrefab.GetComponent<Tonado>();
            obj.transform.parent = sea;
            obj.transform.localScale = new Vector3(1, 0, 1);
            obj.transform.localPosition = new Vector3(Random.Range(-930, 930), 650);
            obj.gameObject.SetActive(true);

            obj.transform.DOScaleY(20, 1.3f).OnComplete(() => StartCoroutine(obj.Duration(3f)));
        }

        yield return null;

        body.StateReset();
    }
}
