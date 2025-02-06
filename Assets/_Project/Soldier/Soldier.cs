using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
	SoldierColorController soldierColorController;
	SoldierHealth soldierHealth;

	public SoldierColorController SoldierColorController => soldierColorController;
	public SoldierHealth SoldierHealth => soldierHealth;

	private void Awake()
	{
		soldierColorController = GetComponent<SoldierColorController>();
		soldierHealth = GetComponent<SoldierHealth>();
	}
}
