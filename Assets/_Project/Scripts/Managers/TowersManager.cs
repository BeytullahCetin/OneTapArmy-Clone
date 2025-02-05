using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersManager : MonoBehaviour
{
	PlayerTower playerTower;
	EnemyTower[] enemyTowers;

	public PlayerTower PlayerTower => playerTower;
	public EnemyTower[] EnemyTowers => enemyTowers;

	public void GetTowerReferances()
	{
		playerTower = FindAnyObjectByType<PlayerTower>();
		enemyTowers = FindObjectsByType<EnemyTower>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
	}
}
