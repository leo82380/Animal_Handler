using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttackChoiceItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private PlayerAttackChoicePanel _playerAttackChoicePanel;
    [SerializeField] private AnimalGet _animalGet;
    [SerializeField] private AttackChoiceSO _attackChoiceSO;
    [SerializeField] private TextMeshProUGUI _percentageText;
    [SerializeField] private TextMeshProUGUI _upgradeValueText;
    
    public AttackChoiceSO AttackChoiceSO => _attackChoiceSO;
    
    public void SetData()
    {
        _percentageText.text = $"성공 확률: {_attackChoiceSO.percentage}%";
        _upgradeValueText.text = $"증가량: {_attackChoiceSO.UpgradeValue}";
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(1);

        int random = Random.Range(0, 100);
        if (random < _attackChoiceSO.percentage)
        {
            _animalGet.Percentage += _attackChoiceSO.UpgradeValue;
        }
        _playerAttackChoicePanel.Close();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(new Vector3(1, 1, 1), 0.3f);
    }
}