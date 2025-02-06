using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "XPLevelsSO", menuName = "ScriptableObjects/XPLevelsSO")]
public class XPLevelsSO : ScriptableObject
{
	[SerializeField] List<XPLevelData> levelDataList = new List<XPLevelData>();
	[SerializeField] float multiplier = 1.5f;

	public XPLevelData GetLevelData(int level)
	{
		int existingLevelCount = levelDataList.Count;
		if (level <= existingLevelCount)
			return levelDataList[level - 1];

		int missingLevelCount = level - existingLevelCount;

		XPLevelData lastLevelData = levelDataList.Last();
		XPLevelData newLevelData = new XPLevelData();
		newLevelData.xpRequired = Mathf.RoundToInt(lastLevelData.xpRequired * Mathf.Pow(multiplier, missingLevelCount));

		return newLevelData;
	}

	[Button]
	private void TestLevels()
	{
		for (int i = 1; i <= 15; i++)
		{
			XPLevelData levelData = GetLevelData(i);
			Debug.Log($"Level {i} -> required xp: {levelData.xpRequired}");
		}
	}
}

[Serializable]
public class XPLevelData
{
	public float xpRequired;
}