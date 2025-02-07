using NaughtyAttributes;
using UnityEngine;

public class TowerLevelController : MonoBehaviour
{
	DeckManager deckManager;
	TowerHudController towerHudController;
	TowerModelController towerModelController;
	TowerHealthController towerHealthController;

	public int Level
	{
		get => currentLevel;
		set
		{
			currentLevel = value;
			UpdateLevel();
		}
	}
	[SerializeField] int currentLevel = 1;

	private void Awake()
	{
		towerHudController = GetComponent<TowerHudController>();
		towerModelController = GetComponent<TowerModelController>();
		towerHealthController = GetComponent<TowerHealthController>();
		deckManager = FindAnyObjectByType<DeckManager>();
	}

	public void Initialize()
	{
		Level = 1;
	}

	[Button]
	public void UpdateLevel()
	{
		towerHudController.Level.FillText($"{currentLevel}");
		towerModelController.UpdateModel();
		towerHealthController.UpdateHealthLevel(deckManager.TowerCardSO, deckManager.TowerCardSO.Levels[Level]);
	}

	public void IncreaseLevel()
	{
		Level++;
	}
}
