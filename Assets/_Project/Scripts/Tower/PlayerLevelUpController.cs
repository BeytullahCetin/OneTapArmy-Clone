using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerLevelUpController : MonoBehaviour
{
	PlayerXPController playerXPController;
	DeckManager deckManager;
	LevelUpManager levelUpManager;

	List<SoldierCardSO> soldierCardSOs = new List<SoldierCardSO>();
	List<TowerCardSO> towerCardSOs = new List<TowerCardSO>();
	List<UpgradeCardData> upgradeCards = new List<UpgradeCardData>();

	private void Awake()
	{
		deckManager = FindAnyObjectByType<DeckManager>();
		levelUpManager = FindAnyObjectByType<LevelUpManager>();
		playerXPController = GetComponent<PlayerXPController>();
	}

	public void Initialize()
	{
		towerCardSOs.Clear();
		towerCardSOs.Add(deckManager.TowerCardSO);

		soldierCardSOs = deckManager.SpawnableSoldiers.ToList();

		playerXPController.LevelIncreasedEvent.RemoveListener(OnLevelIncreased);
		playerXPController.LevelIncreasedEvent.AddListener(OnLevelIncreased);
	}

	private void OnLevelIncreased()
	{
		upgradeCards.Clear();

		foreach (var card in soldierCardSOs)
		{
			if (card.CurrentCardLevelIndex >= card.Levels.Count)
				continue;

			UpgradeCardData upgradeCardData = new UpgradeCardData();
			upgradeCardData.cardSO = card;
			upgradeCardData.level = card.Levels[card.CurrentCardLevelIndex + 1];
			upgradeCards.Add(upgradeCardData);
		}

		foreach (var card in towerCardSOs)
		{
			if (card.CurrentCardLevelIndex >= card.Levels.Count)
				continue;

			UpgradeCardData upgradeCardData = new UpgradeCardData();
			upgradeCardData.cardSO = card;
			upgradeCardData.level = card.Levels[card.CurrentCardLevelIndex + 1];
			upgradeCards.Add(upgradeCardData);
		}

		List<UpgradeCardData> rewards = upgradeCards.OrderBy(x => Guid.NewGuid()).Take(3).ToList();
		if (rewards.Count <= 0)
			return;

		levelUpManager.ShowLevelupCards(rewards);
	}
}

public class UpgradeCardData
{
	public CardSO cardSO;
	public CardLevel level;
}
