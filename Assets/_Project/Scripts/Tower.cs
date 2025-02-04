using UnityEngine;

public class Tower : MonoBehaviour
{
	TowerLevelController towerLevel;
	TowerModelController towerModel;
	TowerHealthController towerHealth;

	private void Awake()
	{
		towerLevel = GetComponent<TowerLevelController>();
		towerModel = GetComponent<TowerModelController>();
		towerHealth = GetComponent<TowerHealthController>();
	}

	private void Start()
	{
		towerLevel.Initialize();
		towerHealth.Initialize();
		towerModel.Initialize();
	}
}