using System.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine;

public class Soldier : MonoBehaviour
{
	[Header("Debug")]
	[ReadOnly][SerializeField] string stateDebugger = "";

	SoldierColorController soldierColorController;
	SoldierHealth soldierHealth;
	SoldierMovement soldierMovement;
	SoldierAnimation soldierAnimation;

	public SoldierColorController SoldierColorController => soldierColorController;
	public SoldierHealth SoldierHealth => soldierHealth;
	public SoldierMovement SoldierMovement => soldierMovement;

	Soldier_BaseState CurrentState;
	Soldier_IdleState IdleState = new Soldier_IdleState();
	Soldier_MoveState MoveState = new Soldier_MoveState();
	Soldier_AttackState AttackState = new Soldier_AttackState();



	public void Initialize()
	{
		soldierColorController = GetComponent<SoldierColorController>();
		soldierHealth = GetComponent<SoldierHealth>();
		soldierMovement = GetComponent<SoldierMovement>();
		soldierAnimation = GetComponent<SoldierAnimation>();

		soldierColorController.Initialize();
		soldierMovement.Initialize();
	}

	public void SwitchState(Soldier_BaseState state)
	{
		if (CurrentState != null)
			CurrentState.ExitState(this);

		CurrentState = state;
		stateDebugger = $"{CurrentState.GetType()}";
		CurrentState.EnterState(this);
	}

	public void SwitchToIdleState()
	{
		SwitchState(IdleState);
	}

	public async void Move(Vector3 target)
	{
		if (CanMove() == false)
			return;

		// SwitchState(MoveState);
		bool isReached = await SoldierMovement.MoveToPosition(target);
		if (isReached)
		{
			soldierAnimation.StopRunAnimation();
		}
	}

	public void Attack(Health health)
	{
		Move(health.transform.position);
		if ((transform.position - health.transform.position).sqrMagnitude > 1)
			SwitchToIdleState();
		return;

		// SwitchState(AttackState);
		// TODO: Attack
	}

	private bool CanMove()
	{
		return true;
	}
}
