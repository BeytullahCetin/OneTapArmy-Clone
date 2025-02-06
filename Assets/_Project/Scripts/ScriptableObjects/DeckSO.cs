using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "DeckSO", menuName = "ScriptableObjects/DeckSO")]

public class DeckSO : ScriptableObject
{
	[Expandable][SerializeField] List<DeckCardSO> deck = new List<DeckCardSO>();
	public List<DeckCardSO> Deck => deck;
}
