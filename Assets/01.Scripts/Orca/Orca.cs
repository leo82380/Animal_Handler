using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orca : MonoBehaviour
{
    public OState[] stateList;
    public PlayerAttackChoicePanel ap;
    public Collider2D he;

    [Range(1,4)]public int level = 1;

    public bool canUseSkill = false;

    public bool filedIsWater = false;

    private void Awake()
    {
        stateList = GetComponentsInChildren<OState>();
    }

    public void Start()
    {
        StartCoroutine(PlayerAttack());
        StartCoroutine(StateReset());
    }

    public IEnumerator PlayerAttack()
    {
        he.enabled = true;
        canUseSkill = true;
        yield return new WaitForSeconds(25);
        he.enabled = false;
        ap.Open();
        canUseSkill = false;
    }

    private int SelectInt()
    {
        return Random.Range(1, 4 + (level >= 3 ? 1 : 0)) + (filedIsWater ? 1 : 0);
    }

    public IEnumerator StateReset()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));

        UseSkill();
    }

    public void UseSkill()
    {
        int num = SelectInt();

        if(num == 4 && ap._animalGet.Percentage < 40)
        {
            num = 3;
        }
        Debug.Log(num + " / " + canUseSkill);
        if(canUseSkill)
            StartCoroutine(stateList[num].UseSkill());
    }
}
