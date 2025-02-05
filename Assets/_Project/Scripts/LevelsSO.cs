using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsSO", menuName = "ScriptableObjects/LevelsSO")]
public class LevelsSO : ScriptableObject
{
	[SerializeField] List<LevelData> levelDataList = new List<LevelData>();
	public List<LevelData> LevelDataList => levelDataList;
}

[Serializable]
public class LevelData
{
	[Range(1, 3)] public int enemyCount;
	// TODO: difficulty
	// TODO: card rarity
}