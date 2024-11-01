using UnityEngine;

[CreateAssetMenu(menuName = "SO/AttackChoiceSO")]
public class AttackChoiceSO : ScriptableObject
{
    public int percentage;
    public int UpgradeValue;
    
    public void SetRandomGenerate()
    {
        percentage = Random.Range(20, 100);
        UpgradeValue = Random.Range(3, 20);
    }
}