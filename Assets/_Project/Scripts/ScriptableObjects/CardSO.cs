using NaughtyAttributes;
using UnityEngine;

public abstract class CardSO : ScriptableObject
{
	public string Name => cardName;
	public Sprite Icon => icon;
	public float Health => health;

	[SerializeField] string cardName;
	[ShowAssetPreview][SerializeField] protected Sprite icon;
	[SerializeField] protected float health;

	public int CurrentCardLevelIndex { get; set; }
	public abstract void UpgradeCard();
}

public abstract class CardLevel
{
	[ShowAssetPreview] public Sprite icon;
	[TextArea] public string description;
}