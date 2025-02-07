using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelUpManager : MonoBehaviour
{
	[SerializeField] LevelUpCard levelUpCardPrefab;
	[SerializeField] LevelUp_UI levelUp_UI;

	private void Awake()
	{
		levelUp_UI.DisableLevelUpCardsPanel();
	}

	public void ShowLevelupCards(List<UpgradeCardData> rewards)
	{
		levelUp_UI.ClearLevelUpCards();
		LevelUpCard.OnCardLevelUp = new UnityEvent();

		foreach (UpgradeCardData card in rewards)
		{
			LevelUpCard levelUpCard = Instantiate(levelUpCardPrefab, levelUp_UI.LevelUpCardsParent);
			levelUpCard.SetCard(card);

			LevelUpCard.OnCardLevelUp.AddListener(() =>
			{
				levelUp_UI.DisableLevelUpCardsPanel();
				ResumeGame();
			});
		}

		levelUp_UI.EnableLevelUpCardsPanel();
		PauseGame();
	}

	private void PauseGame()
	{
		Time.timeScale = 0;
	}

	private void ResumeGame()
	{
		Time.timeScale = 1;
	}
}
