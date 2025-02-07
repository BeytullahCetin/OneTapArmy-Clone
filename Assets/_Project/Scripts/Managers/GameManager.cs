using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] TowersManager towersManager;
	[SerializeField] LevelManager levelManager;
	[SerializeField] MainMenuManager mainMenuManager;
	[SerializeField] DeckManager deckManager;

	private void Start()
	{
		levelManager.LoadLevel();
		mainMenuManager.Initialize();
		levelManager.CreateLevelCards();
		deckManager.CreateDeckCards();
	}

	public void PrepareGame(int levelIndex)
	{
		LevelData levelData = levelManager.LevelsSO.LevelDataList[levelIndex];
		towersManager.SetEnemyTowerCount(levelData.enemyCount);
		deckManager.ResetSoldierLevels();
	}

	public void StartGame(int levelIndex)
	{
		PrepareGame(levelIndex);
		towersManager.Initialize();
	}

	public void StopGame()
	{
		Debug.Log("TODO: Stop Game");
	}
}
