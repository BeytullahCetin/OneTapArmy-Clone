using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class PlayerXPController : MonoBehaviour
{
	public UnityEvent PostIncreaseXPEvent { get; private set; }
	public UnityEvent LevelIncreasedEvent { get; private set; }

	[Expandable][SerializeField] XPLevelsSO levelsSO;

	[SerializeField] int currentLevel;
	[SerializeField] float currentXp;
	[SerializeField] float currentLevelXp;

	XPUI xPUI;
	XPLevelData currentLevelData;


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

			LevelIncreasedEvent.Invoke();
		}

		xPUI.UpdateXPUI(currentLevel, currentLevelXp, currentLevelData.xpRequired);
		PostIncreaseXPEvent.Invoke();
	}

	private void Awake()
	{
		xPUI = FindAnyObjectByType<XPUI>();
		PostIncreaseXPEvent = new UnityEvent();
		LevelIncreasedEvent = new UnityEvent();
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
