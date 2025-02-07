using UnityEngine;

public class LevelUp_UI : MonoBehaviour
{
	[SerializeField] GameObject LevelupCardsUI;
	[SerializeField] Transform levelUpCardsParent;
	public Transform LevelUpCardsParent => levelUpCardsParent;

	public void EnableLevelUpCardsPanel()
	{
		LevelupCardsUI.SetActive(true);
	}

	public void DisableLevelUpCardsPanel()
	{
		LevelupCardsUI.SetActive(false);
	}

	public void ClearLevelUpCards()
	{
		foreach (Transform card in levelUpCardsParent)
		{
			Destroy(card.gameObject);
		}
	}
}
