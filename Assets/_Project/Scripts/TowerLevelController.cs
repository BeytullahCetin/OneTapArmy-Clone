using UnityEngine;

public class TowerLevelController : MonoBehaviour
{
	TowerHudController towerHudController;

	public int Level
	{
		get => currentLevel;
		set
		{
			currentLevel = value;
			towerHudController.Level.FillText($"{currentLevel}");
		}
	}
	[SerializeField] int currentLevel = 1;

	private void Awake()
	{
		towerHudController = GetComponent<TowerHudController>();
	}

	public void Initialize()
	{
		Level = 1;
	}
}
