using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using ObjectPooling;

public class Orca_p_1 : OState
{
    [SerializeField] private Transform sea;
    [SerializeField] private Transform orcaVisual;
    internal Transform sign;
    [SerializeField] private Transform orcaVisual2;
    internal Transform sign2;

    [SerializeField] private bool reflectionDir = false;
    [SerializeField] private bool reflectionDir2 = false;


    public override void Start()
    {
        body = GetComponentInParent<Orca>();
        orcaVisual.gameObject.SetActive(false);
        orcaVisual2.gameObject.SetActive(false);


        sign = PoolingManager.Instnace.Pop(PoolingType.Water_Bubble).ObjectPrefab.transform;
        sign.gameObject.SetActive(false);
        sign.parent = sea;
        sign.localScale = Vector3.one;
        sign.localPosition = new Vector3(0, 1150);

        orcaVisual.GetComponent<OrcaSlave>().target = sign.GetComponent<Collider2D>();

        sign2 = PoolingManager.Instnace.Pop(PoolingType.Water_Bubble).ObjectPrefab.transform;
        sign2.gameObject.SetActive(false);
        sign2.parent = sea;
        sign2.localScale = Vector3.one;
        sign2.localPosition = new Vector3(0, 1150);

        orcaVisual2.GetComponent<OrcaSlave>().target = sign2.GetComponent<Collider2D>();
    }

    public override IEnumerator UseSkill()
    {
        int xPos = Random.Range(-750, 751);
        orcaVisual.localPosition = new Vector2(xPos, -680);
        reflectionDir = xPos > 0;
        orcaVisual.rotation = Quaternion.Euler(0, 0, xPos > 0 ? 12 : 168);
        orcaVisual.gameObject.SetActive(true);

        sign.gameObject.SetActive(true);
        sign.position = new Vector2(orcaVisual.position.x, sign.position.y);
        

        if (body.level <= 2)
        {
            int xPos2 = Random.Range(-750, 751);
            orcaVisual2.localPosition = new Vector2(xPos2, -680);
            reflectionDir2 = xPos2 > 0;
            orcaVisual2.rotation = Quaternion.Euler(0, 0, xPos2 > 0 ? 12 : 168);
            orcaVisual2.gameObject.SetActive(true);

            sign2.gameObject.SetActive(true);
            sign2.position = new Vector2(orcaVisual2.position.x, sign2.position.y);
        }
        
        yield return new WaitForSeconds(1.8f);

        float timer = Random.Range(1.5f, 1.9f);
        orcaVisual.DOJump(new Vector3(orcaVisual.position.x + Random.Range(30, 60) * (reflectionDir ? -1 : 1),
            orcaVisual.position.y), Random.Range(30, 40), 1, timer)
            .OnStart(()=>orcaVisual.DORotate(new Vector3(0, 0, reflectionDir ? 168 : 12), timer - 0.5f));

        if(body.level <= 2)
        {
            timer = Random.Range(1.5f, 1.9f);
            orcaVisual2.DOJump(new Vector3(orcaVisual2.position.x + Random.Range(30, 60) * (reflectionDir2 ? -1 : 1),
                orcaVisual2.position.y), Random.Range(30, 40), 1, timer)
                .OnStart(() => orcaVisual2.DORotate(new Vector3(0, 0, reflectionDir2 ? 168 : 12), timer - 0.5f));
        }
        



        body.StateReset();
    }
}
