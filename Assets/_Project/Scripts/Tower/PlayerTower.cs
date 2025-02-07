using UnityEngine;

public class PlayerTower : MonoBehaviour
{
	Tower tower;
	PlayerXPController xPController;
	PlayerLevelUpController playerLevelUpController;

	private void Awake()
	{
		tower = GetComponent<Tower>();
		xPController = GetComponent<PlayerXPController>();
		playerLevelUpController = GetComponent<PlayerLevelUpController>();
	}

	public void Initialize()
	{
		tower.Initialize();
		xPController.Initialize();
		playerLevelUpController.Initialize();
	}
}