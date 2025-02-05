using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class PlayerXPController : MonoBehaviour
{
	public UnityEvent PostIncreaseXPEvent { get; private set; }

	[SerializeField] LevelsSO levelsSO;

	[SerializeField] int currentLevel;
	[SerializeField] float currentXp;
	[SerializeField] float currentLevelXp;

	XPUI xPUI;
	LevelData currentLevelData;


	[Button]
	public void IncreaseXPTest()
	{
		IncreaseXP(3);
	}

	public void IncreaseXP(float xp)
	{
		currentXp += xp;
		currentLevelXp += xp;

		if (currentLevelXp >= currentLevelData.xpRequired)
		{
			currentLevel++;
			currentLevelXp -= currentLevelData.xpRequired;
			currentLevelData = levelsSO.GetLevelData(currentLevel);
		}

		xPUI.UpdateXPUI(currentLevel, currentLevelXp, currentLevelData.xpRequired);
		PostIncreaseXPEvent.Invoke();
	}

	private void Awake()
	{
		xPUI = FindAnyObjectByType<XPUI>();
		PostIncreaseXPEvent = new UnityEvent();
	}

	public void Initialize()
	{
		currentLevel = 1;
		currentXp = 0;
		currentLevelXp = 0;
		xPUI.XpBar.value = 0;

		currentLevelData = levelsSO.GetLevelData(currentLevel);
		xPUI.UpdateXPUI(currentLevel, currentLevelXp, currentLevelData.xpRequired);
	}
}
