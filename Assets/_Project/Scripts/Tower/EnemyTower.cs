using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTower : MonoBehaviour
{
	Tower tower;

	private void Awake()
	{
		tower = GetComponent<Tower>();
	}

	public void Initialize()
	{
		tower.Initialize();
	}
}
