using UnityEngine.Events;

public class SoldierHealth : Health
{
	SoldierHud soldierHud;

	public override void Initialize(float maxHp)
	{
		soldierHud = GetComponent<SoldierHud>();
		soldierHud.HealthBar.minValue = 0;

		this.maxHp = maxHp;
		currentHp = maxHp;
		DeadEvent = new UnityEvent();

		UpdateHealthBar();
	}

	protected override void UpdateHealthBar()
	{
		soldierHud.HealthBar.maxValue = maxHp;
		soldierHud.HealthBar.value = currentHp;
	}
}
