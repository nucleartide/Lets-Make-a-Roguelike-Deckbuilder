using UnityEngine;
using TMPro;

public class CardPresenter : MonoBehaviour
{
    [SerializeField]
    public CardStatistics cardStatistics;

    public string id;

    [SerializeField]
    TMP_Text attackText;

    [SerializeField]
    TMP_Text healthText;

    [SerializeField]
    TMP_Text summonCostText;

    [SerializeField]
    TMP_Text nameText;

    void Start()
    {
        attackText.text = "ATK: " + cardStatistics.Attack.ToString();
        healthText.text = "HP: " + cardStatistics.CurrentHealth.ToString();
        summonCostText.text = "COST: " + cardStatistics.SummonCost.ToString();
        nameText.text = cardStatistics.Name;
    }
}
