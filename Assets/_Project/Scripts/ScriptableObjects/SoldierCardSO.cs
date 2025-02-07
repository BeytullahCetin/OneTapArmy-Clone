using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SoldierCardSO", menuName = "ScriptableObjects/SoldierCardSO")]

public class SoldierCardSO : CardSO
{
	public UnityEvent CardStateChanged { get; private set; }

	public float Damage => damage;
	public List<SoldierLevel> Levels => soldierLevels;

	[SerializeField] float damage;
	[SerializeField] List<SoldierLevel> soldierLevels = new List<SoldierLevel>();

	string CardLockPPKey => $"Card_IsLocked_{Name}";
	string CardSelectPPKey => $"Card_IsSelected_{Name}";

	public void SetPlayerPrefsIfNotExists()
	{
		if (PlayerPrefs.HasKey(CardLockPPKey) == false)
		{
			PlayerPrefs.SetInt(CardLockPPKey, 1);
		}

		if (PlayerPrefs.HasKey(CardSelectPPKey) == false)
		{
			PlayerPrefs.SetInt(CardSelectPPKey, 1);
		}
	}

	public bool IsLocked()
	{
		int isLocked = PlayerPrefs.GetInt(CardLockPPKey, 1);
		return isLocked == 1;
	}

	public bool IsSelected()
	{
		int isSelected = PlayerPrefs.GetInt(CardSelectPPKey, 1);
		return isSelected == 1;
	}

	public void SwitchSelectState()
	{
		SetSelectState(IsSelected() ? false : true);
	}

	public void SetCardLock(bool isLocked)
	{
		PlayerPrefs.SetInt(CardLockPPKey, isLocked ? 1 : 0);
		CardStateChanged.Invoke();
	}

	public void SetSelectState(bool isSelected)
	{
		PlayerPrefs.SetInt(CardSelectPPKey, isSelected ? 1 : 0);
		CardStateChanged.Invoke();
	}

	public void ResetCardStateChangeEvent()
	{
		CardStateChanged = new UnityEvent();
	}

	[Button]
	public void UnlockCard()
	{
		SetCardLock(false);
	}

	[Button]
	public void LockCard()
	{
		SetCardLock(true);
	}

	public override void UpgradeCard()
	{
		CurrentCardLevelIndex++;
		//TODO: Event for particle effects
	}
}

[Serializable]
public class SoldierLevel : CardLevel
{
	public Soldier soldierPrefab;
	public float healthMultiplier;
	public float damageMultiplier;
}
