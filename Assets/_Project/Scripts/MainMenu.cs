using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	// Home
	[Header("Home")]
	[SerializeField] Button playButton;
	[SerializeField] Button deckButton;
	[SerializeField] Transform home;

	// Level Selection
	[Header("Level Selection")]
	[SerializeField] Button levelSelectionBackButton;
	[SerializeField] Transform levelSelection;
	[SerializeField] Transform levelCardsParent;

	// Deck Selection
	[Header("Deck Selection")]
	[SerializeField] Button deckSelectionBackButton;
	[SerializeField] Transform deckSelection;
	[SerializeField] Transform deckCardsParent;

	public Button PlayButton => playButton;
	public Button DeckButton => deckButton;
	public Button LevelSelectionBackButton => levelSelectionBackButton;
	public Button DeckSelectionBackButton => deckSelectionBackButton;

	public Transform Home => home;
	public Transform LevelSelection => levelSelection;
	public Transform DeckSelection => deckSelection;

	public Transform LevelCardsParent => levelCardsParent;
	public Transform DeckCardsParent => deckCardsParent;

}
