using UnityEngine;

public class Tower : MonoBehaviour
{
	TowerLevelController towerLevel;
	TowerModelController towerModel;
	TowerHealthController towerHealth;
	TowerSpawnBar towerSpawn;

	public TowerHealthController TowerHealth => towerHealth;
	public TowerLevelController TowerLevel => towerLevel;

	[SerializeField] TowerCardSO towerCardSO;

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
		towerHealth.Initialize(towerCardSO.Health);
		towerSpawn.Initialize();
	}
}