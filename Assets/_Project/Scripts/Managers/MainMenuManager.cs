using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
	[SerializeField] GameManager gameManager;
	[SerializeField] LevelManager levelManager;
	[SerializeField] LevelCard levelCardPrefab;
	[SerializeField] SettingsPanel settingsPanel;
	[SerializeField] SettingsManager settingsManager;
	[SerializeField] MainMenu mainMenu;

	List<LevelCard> levelCards = new List<LevelCard>();

	public bool IsMainMenu => mainMenu.gameObject.activeSelf;

	public void Initialize()
	{
		mainMenu.PlayButton.onClick.AddListener(GoLevelSelection);
		mainMenu.BackButton.onClick.AddListener(GoHome);
		settingsPanel.HomeButton.onClick.AddListener(ReturnToMainMenu);

		GoHome();
		CreateLevelCards();
	}

	public void CreateLevelCards()
	{
		for (int i = 0; i < levelManager.LevelsSO.LevelDataList.Count; i++)
		{
			int levelIndex = i;
			int levelNo = i + 1;
			LevelData levelData = levelManager.LevelsSO.LevelDataList[i];
			LevelCard levelCard = Instantiate(levelCardPrefab, mainMenu.LevelCardsParent);
			levelCards.Add(levelCard);

			levelCard.LevelText.FillText(levelNo.ToString());
			levelCard.PlayButton.onClick.RemoveAllListeners();
			levelCard.PlayButton.onClick.AddListener(() =>
			{
				DisableMainMenu();
				gameManager.StartGame(levelIndex);
			});
		}

		UpdateLevelCards();
	}

	public void UpdateLevelCards()
	{
		// TODO: Get Current Level from PlayerPrefs
		int curretLevel = levelManager.CurrentLevel;
		for (int i = 0; i < levelCards.Count; i++)
		{
			LevelCard levelCard = levelCards[i];

			int levelNo = i + 1;
			bool isUnlocked = curretLevel >= levelNo;

			levelCard.Unlocked.SetActive(isUnlocked);
			levelCard.Locked.SetActive(!isUnlocked);
		}
	}

	public void GoHome()
	{
		mainMenu.Home.gameObject.SetActive(true);
		mainMenu.LevelSelection.gameObject.SetActive(false);
	}

	public void GoLevelSelection()
	{
		mainMenu.Home.gameObject.SetActive(false);
		mainMenu.LevelSelection.gameObject.SetActive(true);
	}

	public void DisableMainMenu()
	{
		mainMenu.gameObject.SetActive(false);
	}

	public void EnableMainMenu()
	{
		mainMenu.gameObject.SetActive(true);
	}

	public void ReturnToMainMenu()
	{
		gameManager.StopGame();
		GoHome();
		EnableMainMenu();
		settingsManager.CloseSettingsPanel();
	}
}
