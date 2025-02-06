using UnityEngine.Events;
using UnityEngine;
using NaughtyAttributes;


public abstract class Health : MonoBehaviour
{
	public UnityEvent DeadEvent { get; protected set; }

	protected float maxHp;
	[ReadOnly][SerializeField] protected float currentHp;

	protected abstract void UpdateHealthBar();
	public abstract void Initialize(float maxHp);

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
			DeadEvent.Invoke();
		}
	}
}