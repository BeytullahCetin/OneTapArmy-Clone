using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Events;

public class SoldierHealth : MonoBehaviour
{
	public UnityEvent SoldierDeadEvent { get; private set; }

	Soldier soldier;
	SoldierHud soldierHud;

	float maxHp;
	[ReadOnly][SerializeField] float currentHp;

	private void Awake()
	{
		soldierHud = GetComponent<SoldierHud>();
	}

	public void Initialize(float maxHp)
	{
		this.maxHp = maxHp;
		currentHp = maxHp;
		SoldierDeadEvent = new UnityEvent();

		UpdateHealthBar();
	}

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

	public void DecreaseHealth(float hp)
	{
		Hp -= hp;

		if (Hp <= 0)
		{
			SoldierDeadEvent.Invoke();
		}
	}

	private void UpdateHealthBar()
	{
		soldierHud.HealthBar.maxValue = maxHp;
		soldierHud.HealthBar.value = currentHp;
	}
}
