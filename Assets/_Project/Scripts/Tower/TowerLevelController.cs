using NaughtyAttributes;
using UnityEngine;

public class TowerLevelController : MonoBehaviour
{
	TowerHudController towerHudController;
	TowerModelController towerModelController;

	public int Level
	{
		get => currentLevel;
		set
		{
			currentLevel = value;
			UpdateLevel();
		}
	}
	[SerializeField] int currentLevel = 1;

	private void Awake()
	{
		towerHudController = GetComponent<TowerHudController>();
		towerModelController = GetComponent<TowerModelController>();
	}

	public void Initialize()
	{
		Level = 1;
	}

	[Button]
	public void UpdateLevel()
	{
		towerHudController.Level.FillText($"{currentLevel}");
		towerModelController.UpdateModel();
	}
}
