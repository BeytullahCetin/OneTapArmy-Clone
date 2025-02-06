using UnityEngine;

public class PlayerTower : MonoBehaviour
{
	Tower tower;
	PlayerXPController xPController;

	private void Awake()
	{
		tower = GetComponent<Tower>();
		xPController = GetComponent<PlayerXPController>();
	}

	public void Initialize()
	{
		tower.Initialize();
		xPController.Initialize();
	}
}
