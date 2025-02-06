using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "SoldierCardSO", menuName = "ScriptableObjects/SoldierCardSO")]

public class SoldierCardSO : ScriptableObject
{
	public UnityEvent CardStateChanged { get; private set; }

	public string Name => soldierName;
	public Sprite Icon => icon;
	public float Health => health;
	public Soldier SoldierPrefab => soldierPrefab;

	[SerializeField] string soldierName;
	[ShowAssetPreview][SerializeField] Sprite icon;
	[SerializeField] float health;
	[SerializeField] Soldier soldierPrefab;

	string CardLockPPKey => $"Card_IsLocked_{soldierName}";
	string CardSelectPPKey => $"Card_IsSelected_{soldierName}";

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
}
