using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
	[SerializeField] MainMenuManager mainMenuManager;
	[SerializeField] SoldierDB soldierDB;
	[SerializeField] DeckCard deckCardPrefab;

	List<DeckCard> deckCards = new List<DeckCard>();

	public SoldierDB SoldierDB => soldierDB;

	public void CreateDeckCards()
	{
		CreatePlayerPrefsIfNotExists();

		foreach (SoldierCardSO cardSO in soldierDB.SoldierCards)
		{
			DeckCard deckCard = Instantiate(deckCardPrefab, mainMenuManager.MainMenu.DeckCardsParent);
			deckCards.Add(deckCard);
			deckCard.SetSO(cardSO);

			deckCard.SelectButton.onClick.AddListener(() =>
			{
				if (deckCard.DeckCardSO.IsSelected() == true &&
					deckCards.Select(x => x.DeckCardSO).Where(x => x.IsSelected() == true && x.IsLocked() == false).Count() <= 1)
					return;

				cardSO.SwitchSelectState();
			});

			cardSO.ResetCardStateChangeEvent();
			cardSO.CardStateChanged.AddListener(() =>
			{
				deckCard.UpdateLockState();
				deckCard.UpdateSelectState();
			});
		}

		DeckCard firstCard = deckCards.First();
		SoldierCardSO firstCardSO = firstCard.DeckCardSO;

		if (firstCardSO.IsLocked() == true)
		{
			firstCardSO.SetCardLock(false);
			firstCardSO.SetSelectState(true);
			firstCard.UpdateLockState();
			firstCard.UpdateSelectState();
		}
	}

	public void UpdateDeckCards()
	{
		foreach (DeckCard deckCard in deckCards)
		{
			deckCard.UpdateLockState();
			deckCard.UpdateSelectState();
		}
	}

	public void CreatePlayerPrefsIfNotExists()
	{
		foreach (SoldierCardSO cardSO in soldierDB.SoldierCards)
		{
			cardSO.SetPlayerPrefsIfNotExists();
		}
	}
}
