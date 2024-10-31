using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class OState : MonoBehaviour
{
    internal Orca body;
    public abstract IEnumerator UseSkill();
    public abstract void Awake();
}
