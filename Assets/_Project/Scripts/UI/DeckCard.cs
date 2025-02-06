using FormatableTextNS;
using UnityEngine;
using UnityEngine.UI;

public class DeckCard : MonoBehaviour
{
	[SerializeField] GameObject locked;
	[SerializeField] GameObject unlocked;
	[SerializeField] GameObject selected;

	[SerializeField] Image cardImage;
	[SerializeField] FormatableText cardName;
	[SerializeField] Button selectButton;

	DeckCardSO currentCardSO;
	public DeckCardSO DeckCardSO => currentCardSO;

	// public GameObject Locked => locked;
	// public GameObject Unlocked => unlocked;
	// public Image CardImage => cardImage;
	// public FormatableText CardName => cardName;
	public Button SelectButton => selectButton;

	public void SetSO(DeckCardSO soldierCardSO)
	{
		currentCardSO = soldierCardSO;

		cardImage.sprite = currentCardSO.Icon;
		cardName.FillText(currentCardSO.Name);

		UpdateLockState();
		UpdateSelectState();
	}

	public void UpdateLockState()
	{
		bool isLocked = currentCardSO.IsLocked();
		locked.SetActive(isLocked);
		unlocked.SetActive(!isLocked);
	}

	public void UpdateSelectState()
	{
		bool isSelected = currentCardSO.IsSelected();
		selected.SetActive(isSelected);
	}
}
