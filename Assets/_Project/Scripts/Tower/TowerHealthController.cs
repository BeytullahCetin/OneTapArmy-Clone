using UnityEngine.Events;

public class TowerHealthController : Health
{
	TowerHudController towerHudController;

	protected void Awake()
	{
		base.Awake();
		towerHudController = GetComponent<TowerHudController>();
	}

	public override void Initialize(float maxHp)
	{
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

	public void UpdateHealthLevel(TowerCardSO towerCardSO, TowerLevel towerLevel)
	{
		float oldMaxHp = maxHp;
		maxHp = towerCardSO.Health * towerLevel.healthMultiplier;

		if (currentHp == oldMaxHp)
			currentHp = maxHp;
		else
			currentHp = currentHp * (maxHp / oldMaxHp);

		UpdateHealthBar();
	}
}
