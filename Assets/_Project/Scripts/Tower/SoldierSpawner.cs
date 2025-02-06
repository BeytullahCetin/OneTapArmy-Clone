using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
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
		spawnableSoldierSOs = deckManager.SoldierDB.SoldierCards.Where(x => x.IsLocked() == false && x.IsSelected() == true).ToList();
	}

	private void Start()
	{
		towerSpawnBar.SpawnEvent.AddListener(SpawnSoldier);
		towerSpawnBar.RestartSpawningEvent.AddListener(ResetSpawnIndex);
	}

	private void ResetSpawnIndex()
	{
		currentSpawnIndex = 0;
	}

	private void SpawnSoldier()
	{
		if (towerSoldierController.Soldiers.Count >= soldierSpawnPoints.Count)
			return;

		int randomIndex = Random.Range(0, spawnableSoldierSOs.Count);
		SoldierCardSO randomCard = spawnableSoldierSOs[randomIndex];

		Soldier soldier = Instantiate(randomCard.SoldierPrefab, soldierSpawnPoints[currentSpawnIndex]);
		soldier.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
		soldier.SoldierColorController.ChangeColor(soldierMaterial, soldierHealthColor);
		soldier.SoldierHealth.Initialize(randomCard.Health);

		towerSoldierController.Soldiers.Add(soldier);

		currentSpawnIndex++;
	}
}
