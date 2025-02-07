using UnityEngine;

public class Soldier : MonoBehaviour
{
	Transform soldierTransform;
	Tower team;
	SoldierColorController soldierColorController;
	SoldierHealth soldierHealth;
	SoldierMovement soldierMovement;
	SoldierAnimation soldierAnimation;

	public SoldierColorController SoldierColorController => soldierColorController;
	public SoldierHealth SoldierHealth => soldierHealth;
	public SoldierMovement SoldierMovement => soldierMovement;

	public void SetTower(Tower tower)
	{
		team = tower;
	}

	public void Initialize()
	{
		soldierTransform = transform;
		soldierColorController = GetComponent<SoldierColorController>();
		soldierHealth = GetComponent<SoldierHealth>();
		soldierMovement = GetComponent<SoldierMovement>();
		soldierAnimation = GetComponent<SoldierAnimation>();

		soldierColorController.Initialize();
		soldierMovement.Initialize();
	}
}
