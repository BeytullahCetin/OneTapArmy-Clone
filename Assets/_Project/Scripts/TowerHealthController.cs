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
			UpdateHealthBar(currentHp);
		}
	}

	public float Hp
	{
		get => currentHp;
		set
		{
			currentHp = value;
			UpdateHealthBar(currentHp);
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

	private void UpdateHealthBar(float hp)
	{
		healthBar.maxValue = maxHp;
		healthBar.value = hp;

		towerHudController.Health.FillText($"{hp}", $"{maxHp}");
	}
}
