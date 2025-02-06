using UnityEngine;

public class Tower : MonoBehaviour
{
	TowerLevelController towerLevel;
	TowerModelController towerModel;
	TowerHealthController towerHealth;
	TowerSpawnBar towerSpawn;

	public TowerHealthController TowerHealth => towerHealth;

	float startingMaxHP = 3000;

	private void Awake()
	{
		towerLevel = GetComponent<TowerLevelController>();
		towerModel = GetComponent<TowerModelController>();
		towerHealth = GetComponent<TowerHealthController>();
		towerSpawn = GetComponent<TowerSpawnBar>();
	}

	public void Initialize()
	{
		towerLevel.Initialize();
		towerModel.Initialize();
		towerHealth.Initialize(startingMaxHP);
		towerSpawn.Initialize();
	}
}