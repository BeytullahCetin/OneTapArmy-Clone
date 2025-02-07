using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoldierSpawner : MonoBehaviour
{
	[SerializeField] List<Transform> soldierSpawnPoints = new List<Transform>();
	[SerializeField] Material soldierMaterial;
	[SerializeField] Color soldierHealthColor;

	Tower tower;
	TowerSpawnBar towerSpawnBar;
	TowerSoldierController towerSoldierController;
	DeckManager deckManager;
	List<SoldierCardSO> spawnableSoldierSOs = new List<SoldierCardSO>();

	int currentSpawnIndex;

	private void Awake()
	{
		tower = GetComponent<Tower>();
		towerSpawnBar = GetComponent<TowerSpawnBar>();
		towerSoldierController = GetComponent<TowerSoldierController>();
		deckManager = FindAnyObjectByType<DeckManager>();
	}

	public void Initialize()
	{
		spawnableSoldierSOs = deckManager.SpawnableSoldiers.ToList();
	}

	private void Start()
	{
		towerSpawnBar.SpawnEvent.AddListener(SpawnSoldier);
		towerSpawnBar.RestartSpawningEvent.AddListener(RestartSpawning);
	}

	private void RestartSpawning()
	{
		currentSpawnIndex = 0;
		Initialize();
	}

	private void SpawnSoldier()
	{
		if (towerSoldierController.Soldiers.Count >= soldierSpawnPoints.Count)
			return;

		int randomIndex = Random.Range(0, spawnableSoldierSOs.Count);
		SoldierCardSO randomCard = spawnableSoldierSOs[randomIndex];
		SoldierLevel soldierLevel = randomCard.Levels[randomCard.CurrentCardLevelIndex];

		Soldier soldier = Instantiate(soldierLevel.soldierPrefab, soldierSpawnPoints[currentSpawnIndex]);
		soldier.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

		soldier.SetTower(tower);
		soldier.Initialize();

		soldier.SoldierColorController.ChangeColor(soldierMaterial, soldierHealthColor);
		soldier.SoldierHealth.Initialize(randomCard.Health * soldierLevel.healthMultiplier);
		// TODO: Set attack damage

		towerSoldierController.Soldiers.Add(soldier);

		currentSpawnIndex++;
	}
}
