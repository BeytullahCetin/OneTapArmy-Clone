using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class TowerHealthController : MonoBehaviour
{
	public UnityEvent TowerDeadEvent { get; private set; }
	TowerHudController towerHudController;
	[SerializeField] float maxHp = 3000;
	[ReadOnly][SerializeField] float currentHp;

	public float MaxHP
	{
		get => maxHp;
		set
		{
			maxHp = value;
			UpdateHealthBar();
		}
	}

	public float Hp
	{
		get => currentHp;
		set
		{
			currentHp = value;
			UpdateHealthBar();
		}
	}

	private void Awake()
	{
		towerHudController = GetComponent<TowerHudController>();
		TowerDeadEvent = new UnityEvent();
	}

	public void Initialize()
	{
		towerHudController.HealthBar.minValue = 0;
		Hp = maxHp;
	}

	public void DecreaseHealth(float hp)
	{
		Hp -= hp;

		if (Hp <= 0)
		{
			TowerDeadEvent.Invoke();
		}
	}

	public void UpdateHealthBar()
	{
		towerHudController.HealthBar.maxValue = maxHp;
		towerHudController.HealthBar.value = currentHp;

		towerHudController.Health.FillText($"{currentHp}", $"{maxHp}");
	}
}
