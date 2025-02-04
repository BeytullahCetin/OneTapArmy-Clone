using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealthController : MonoBehaviour
{
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
	}

	public void Initialize()
	{
		healthBar.minValue = 0;
		Hp = maxHp;
	}

	[Button]
	public void UpdateHealthBar()
	{
		if (currentHp > maxHp)
			currentHp = maxHp;

		healthBar.maxValue = maxHp;
		healthBar.value = currentHp;

		towerHudController.Health.FillText($"{currentHp}", $"{maxHp}");
	}
}
