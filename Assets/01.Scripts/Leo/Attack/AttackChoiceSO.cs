using UnityEngine;

[CreateAssetMenu(menuName = "SO/AttackChoiceSO")]
public class AttackChoiceSO : ScriptableObject
{
    public int percentage;
    public int UpgradeValue;
    
    public void SetRandomGenerate()
    {
        percentage = Random.Range(0, 100);
        UpgradeValue = Random.Range(1, 10);
    }
}