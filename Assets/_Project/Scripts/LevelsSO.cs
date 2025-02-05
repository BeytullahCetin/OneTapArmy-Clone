using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsSO", menuName = "ScriptableObjects/LevelsSO")]
public class LevelsSO : ScriptableObject
{
	[SerializeField] List<LevelData> levelDataList = new List<LevelData>();
	[SerializeField] float multiplier = 1.5f;

	public LevelData GetLevelData(int level)
	{
		int existingLevelCount = levelDataList.Count;
		if (level <= existingLevelCount)
			return levelDataList[level - 1];

		int missingLevelCount = level - existingLevelCount;

		LevelData lastLevelData = levelDataList.Last();
		LevelData newLevelData = new LevelData();
		newLevelData.xpRequired = Mathf.RoundToInt(lastLevelData.xpRequired * Mathf.Pow(multiplier, missingLevelCount));

		return newLevelData;
	}

	[Button]
	private void TestLevels()
	{
		for (int i = 1; i <= 15; i++)
		{
			LevelData levelData = GetLevelData(i);
			Debug.Log($"Level {i} -> required xp: {levelData.xpRequired}");
		}
	}
}

[Serializable]
public class LevelData
{
	public float xpRequired;
}