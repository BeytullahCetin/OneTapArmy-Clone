using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TowersManager : MonoBehaviour
{
	public PlayerTower PlayerTower => playerTower;
	public List<EnemyTower> EnemyTowers => enemyTowers;

	[SerializeField] PlayerTower playerTower;
	[SerializeField] List<EnemyTower> enemyTowers = new List<EnemyTower>();

	TowerHealthController playerHealthController;
	List<TowerHealthController> enemyHealthControllers = new List<TowerHealthController>();

	public void Initialize()
	{
		ListenTowerHealths();
		InitializeTowers();
	}

	public void InitializeTowers()
	{
		PlayerTower.Initialize();
		foreach (var enemyTower in EnemyTowers)
		{
			enemyTower.Initialize();
		}
	}

	public void SetEnemyTowerCount(int count)
	{
		for (int i = 0; i < enemyTowers.Count; i++)
		{
			EnemyTower enemyTower = enemyTowers[i];
			enemyTower.gameObject.SetActive(i < count);
		}
	}

	public void ListenTowerHealths()
	{
		playerHealthController = playerTower.GetComponent<TowerHealthController>();
		enemyTowers.ForEach(x => enemyHealthControllers.Add(x.GetComponent<TowerHealthController>()));

		playerHealthController.DeadEvent.RemoveListener(CheckTowerStatus);
		playerHealthController.DeadEvent.AddListener(CheckTowerStatus);

		enemyHealthControllers.ForEach(x => x.DeadEvent.RemoveListener(CheckTowerStatus));
		enemyHealthControllers.ForEach(x => x.DeadEvent.AddListener(CheckTowerStatus));
	}

	public void CheckTowerStatus()
	{
		Debug.Log("CheckTowerStatus");
		if (playerHealthController.Hp <= 0)
			Debug.Log("player dead! LOSE!");
		else if (enemyHealthControllers.All(x => x.Hp <= 0))
		{
			Debug.Log("all enemies dead! WIN!");
		}
	}
}
