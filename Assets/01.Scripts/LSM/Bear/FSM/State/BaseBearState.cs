using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BaseBearSkill
{
    public List<GameObject> Patterns { get; set; }
    public void SetPatternObj(List<GameObject> list);
}
