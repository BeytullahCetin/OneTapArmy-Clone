using UnityEngine;
using UnityEngine.Events;

public class PlayerTower : MonoBehaviour
{
	Tower tower;
	PlayerXPController xPController;
	PlayerLevelUpController playerLevelUpController;
	DeckManager deckManager;

	private void Awake()
	{
		tower = GetComponent<Tower>();
		xPController = GetComponent<PlayerXPController>();
		playerLevelUpController = GetComponent<PlayerLevelUpController>();

		deckManager = FindAnyObjectByType<DeckManager>();

		deckManager.TowerCardSO.CardUpgraded = new UnityEvent();
		deckManager.TowerCardSO.CardUpgraded.AddListener(tower.TowerLevel.IncreaseLevel);
	}

	public void Initialize()
	{
		tower.Initialize();
		xPController.Initialize();
		playerLevelUpController.Initialize();
	}
}