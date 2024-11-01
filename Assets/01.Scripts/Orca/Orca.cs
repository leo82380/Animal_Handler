using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orca : MonoBehaviour
{
    public OState[] stateList;
    public PlayerAttackChoicePanel ap;

    [Range(1,4)]public int level = 1;

    public bool filedIsWater = false;

    private void Awake()
    {
        stateList = GetComponentsInChildren<OState>();
    }

    private void Start()
    {
        StartCoroutine(StateReset());
        StartCoroutine(PlayerAttack());
    }

    public IEnumerator PlayerAttack()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(3);
        ap.Open();
        yield return new WaitForSeconds(0.7f);
        Time.timeScale = 0;
    }

    private int SelectInt()
    {
        return Random.Range(1, 4 + (level >= 3 ? 1 : 0)) + (filedIsWater ? 1 : 0);
    }

    public IEnumerator StateReset()
    {
        yield return new WaitForSeconds(7 - level + Random.Range(1, 5));

        UseSkill();
    }

    public void UseSkill()
    {
        int num = SelectInt();

        if(num == 4 && ap._animalGet.Percentage < 40)
        {
            num = 3;
        }
        Debug.Log(num);
        StartCoroutine(stateList[num].UseSkill());
    }
}
