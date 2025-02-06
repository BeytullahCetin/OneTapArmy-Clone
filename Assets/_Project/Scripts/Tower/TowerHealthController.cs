using UnityEngine.Events;

public class TowerHealthController : Health
{
	TowerHudController towerHudController;

	public override void Initialize(float maxHp)
	{
		towerHudController = GetComponent<TowerHudController>();
		towerHudController.HealthBar.minValue = 0;

		this.maxHp = maxHp;
		currentHp = maxHp;
		DeadEvent = new UnityEvent();

		UpdateHealthBar();
	}

	protected override void UpdateHealthBar()
	{
		towerHudController.HealthBar.maxValue = maxHp;
		towerHudController.HealthBar.value = currentHp;

		towerHudController.Health.FillText($"{currentHp}", $"{maxHp}");
	}
}
