using System.Collections;
using System.Collections.Generic;
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

	private void Start()
	{
		xPController.Initialize();
	}
}
