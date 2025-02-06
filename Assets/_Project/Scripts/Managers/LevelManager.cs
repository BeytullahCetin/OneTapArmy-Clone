using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public LevelsSO LevelsSO => levelsSO;

	[SerializeField] GameManager gameManager;
	[SerializeField] MainMenuManager mainMenuManager;
	[Expandable][SerializeField] LevelsSO levelsSO;
	[SerializeField] LevelCard levelCardPrefab;

	List<LevelCard> levelCards = new List<LevelCard>();


	int currentLevel = 1;
	public int CurrentLevel => currentLevel;

	public void LoadLevel()
	{
		if (PlayerPrefs.HasKey("Level") == false)
			PlayerPrefs.SetInt("Level", 1);

		currentLevel = PlayerPrefs.GetInt("Level", 1);
	}

	public void CreateLevelCards()
	{
		for (int i = 0; i < LevelsSO.LevelDataList.Count; i++)
		{
			int levelIndex = i;
			int levelNo = i + 1;
			LevelData levelData = LevelsSO.LevelDataList[i];
			LevelCard levelCard = Instantiate(levelCardPrefab, mainMenuManager.MainMenu.LevelCardsParent);
			levelCards.Add(levelCard);

			levelCard.LevelText.FillText(levelNo.ToString());
			levelCard.PlayButton.onClick.RemoveAllListeners();
			levelCard.PlayButton.onClick.AddListener(() =>
			{
				mainMenuManager.DisableMainMenu();
				gameManager.StartGame(levelIndex);
			});
		}

		UpdateLevelCards();
	}

	public void UpdateLevelCards()
	{
		// TODO: Get Current Level from PlayerPrefs
		int curretLevel = CurrentLevel;
		for (int i = 0; i < levelCards.Count; i++)
		{
			LevelCard levelCard = levelCards[i];

			int levelNo = i + 1;
			bool isUnlocked = curretLevel >= levelNo;

			levelCard.Unlocked.SetActive(isUnlocked);
			levelCard.Locked.SetActive(!isUnlocked);
		}
	}
}
