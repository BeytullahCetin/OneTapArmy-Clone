using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] TowersManager towersManager;

	private void Start()
	{

	}

	[Button]
	private void StartTowers()
	{
		towersManager.GetTowerReferances();

		towersManager.PlayerTower.Initialize();
		foreach (var enemyTower in towersManager.EnemyTowers)
		{
			enemyTower.Initialize();
		}
	}
}
