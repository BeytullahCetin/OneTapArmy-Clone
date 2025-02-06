using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
	[SerializeField] GameManager gameManager;
	[SerializeField] LevelManager levelManager;
	[SerializeField] SettingsPanel settingsPanel;
	[SerializeField] SettingsManager settingsManager;

	[SerializeField] MainMenu mainMenu;

	public bool IsMainMenu => mainMenu.gameObject.activeSelf;
	public MainMenu MainMenu => mainMenu;

	public void Initialize()
	{
		mainMenu.PlayButton.onClick.AddListener(GoLevelSelection);
		mainMenu.DeckButton.onClick.AddListener(GoDeckSelection);
		mainMenu.LevelSelectionBackButton.onClick.AddListener(GoHome);
		mainMenu.DeckSelectionBackButton.onClick.AddListener(GoHome);
		settingsPanel.HomeButton.onClick.AddListener(ReturnToMainMenu);

		GoHome();
	}

	public void GoHome()
	{
		mainMenu.Home.gameObject.SetActive(true);
		mainMenu.LevelSelection.gameObject.SetActive(false);
		mainMenu.DeckSelection.gameObject.SetActive(false);
	}

	public void GoLevelSelection()
	{
		mainMenu.Home.gameObject.SetActive(false);
		mainMenu.LevelSelection.gameObject.SetActive(true);
		mainMenu.DeckSelection.gameObject.SetActive(false);
	}

	public void GoDeckSelection()
	{
		mainMenu.Home.gameObject.SetActive(false);
		mainMenu.LevelSelection.gameObject.SetActive(false);
		mainMenu.DeckSelection.gameObject.SetActive(true);
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
