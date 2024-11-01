using UnityEngine;

[CreateAssetMenu(menuName = "SO/AttackChoiceSO")]
public class AttackChoiceSO : ScriptableObject
{
    public int setPercentage;
    public int setUpgrade;
    public int percentage;
    public int UpgradeValue;
    
    public void SetRandomGenerate()
    {
        percentage = Random.Range(setPercentage - 15, setPercentage);
        UpgradeValue = Random.Range(setUpgrade -10, setUpgrade);
    }
}