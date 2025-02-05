using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TowerHealthController : MonoBehaviour
{
	public UnityEvent TowerDeadEvent { get; private set; }
	TowerHudController towerHudController;

	[SerializeField] Slider healthBar;
	[SerializeField] float maxHp = 3000;
	[SerializeField] float currentHp;

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
		healthBar.minValue = 0;
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

	[Button]
	public void DecreaseHealthTest()
	{
		DecreaseHealth(1000);
	}

	public void UpdateHealthBar()
	{
		if (currentHp > maxHp)
			currentHp = maxHp;

		healthBar.maxValue = maxHp;
		healthBar.value = currentHp;

		towerHudController.Health.FillText($"{currentHp}", $"{maxHp}");
	}
}
