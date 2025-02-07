using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerCardSO", menuName = "ScriptableObjects/TowerCardSO")]

public class TowerCardSO : CardSO
{
	public List<TowerLevel> Levels => towerLevels;
	public float SpawnSpeed => spawnSpeed;

	[SerializeField] float spawnSpeed;
	[SerializeField] List<TowerLevel> towerLevels = new List<TowerLevel>();

	public override void UpgradeCard()
	{
		CurrentCardLevelIndex++;
		// TODO: Update tower health and model
	}
}

[Serializable]
public class TowerLevel : CardLevel
{
	public float health;
	public float spawnSpeedMultiplier;
}
