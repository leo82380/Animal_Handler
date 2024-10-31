using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orca : MonoBehaviour
{
    public OState[] stateList;

    [Range(1,4)]public int level = 1;

    public bool filedIsWater = false;

    private void Awake()
    {
        stateList = GetComponentsInChildren<OState>();
    }

    private int SelectInt()
    {
        return Random.Range(1, 4 + (level == 3 ? 1 : 0)) + (filedIsWater ? 1 : 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(UseSkill(0));
        }
    }

    public void StateReset()
    {

    }

    public IEnumerator UseSkill(float _delay)
    {
        yield return new WaitForSeconds(_delay);

        int num = SelectInt();
        Debug.Log(num);
        num = 3;
        StartCoroutine(stateList[num].UseSkill());
    }
}
