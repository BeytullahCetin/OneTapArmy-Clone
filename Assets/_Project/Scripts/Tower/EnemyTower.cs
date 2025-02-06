using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTower : MonoBehaviour
{
	Tower tower;
	public Tower Tower => tower;

	private void Awake()
	{
		tower = GetComponent<Tower>();
	}

	public void Initialize()
	{
		tower.Initialize();
	}
}
