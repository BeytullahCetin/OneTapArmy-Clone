using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "TowerCardSO", menuName = "ScriptableObjects/TowerCardSO")]

public class TowerCardSO : CardSO
{
	public UnityEvent CardUpgraded { get; set; }

	public List<TowerLevel> Levels => towerLevels;
	public float SpawnSpeed => spawnSpeed;

	[SerializeField] float spawnSpeed;
	[SerializeField] List<TowerLevel> towerLevels = new List<TowerLevel>();

	public override void UpgradeCard()
	{
		CardUpgraded.Invoke();
		// CurrentCardLevelIndex++;
		// TODO: Update tower health and model
	}
}

[Serializable]
public class TowerLevel : CardLevel
{
	public float healthMultiplier;
	public float spawnSpeedMultiplier;
}
