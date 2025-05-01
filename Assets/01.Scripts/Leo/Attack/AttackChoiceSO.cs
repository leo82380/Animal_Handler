using UnityEngine;

[CreateAssetMenu(menuName = "SO/AttackChoiceSO")]
public class AttackChoiceSO : ScriptableObject
{
    public Vector2Int selectPercentage;
    public Vector2Int valuePercentage;
    internal int percentage;
    internal int UpgradeValue;
    
    public void SetRandomGenerate()
    {
        percentage = Random.Range(selectPercentage.x, selectPercentage.y + 1);
        UpgradeValue = Random.Range(valuePercentage.x, valuePercentage.y + 1);
    }
}