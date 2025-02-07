using FormatableTextNS;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelUpCard : MonoBehaviour
{
	public static UnityEvent OnCardLevelUp;

	[SerializeField] Image iconImage;
	[SerializeField] FormatableText cardName;
	[SerializeField] FormatableText cardDescription;
	[SerializeField] Button button;

	public void SetCard(UpgradeCardData cardData)
	{
		iconImage.sprite = cardData.cardSO.Icon;
		cardName.FillText(cardData.cardSO.Name);
		cardDescription.FillText(cardData.level.description);
		button.onClick.AddListener(cardData.cardSO.UpgradeCard);
		button.onClick.AddListener(OnCardLevelUp.Invoke);
	}
}
