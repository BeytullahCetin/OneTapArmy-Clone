using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
	[SerializeField] MainMenuManager mainMenuManager;
	[SerializeField] SoldierDB soldierDB;
	[SerializeField] TowerCardSO towerCardSO;
	[SerializeField] DeckCard deckCardPrefab;

	List<DeckCard> deckCards = new List<DeckCard>();

	public SoldierDB SoldierDB => soldierDB;
	public TowerCardSO TowerCardSO => towerCardSO;
	public IEnumerable<SoldierCardSO> SpawnableSoldiers => SoldierDB.SoldierCards.Where(x => x.IsLocked() == false && x.IsSelected() == true);

	public void ResetSoldierLevels()
	{
		soldierDB.SoldierCards.ForEach(x => x.CurrentCardLevelIndex = 0);
	}

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
					deckCards.Select(x => x.DeckCardSO).Where(x => x.IsSelected() == true && x.IsLocked() == false).Count() <= 2)
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

		List<DeckCard> cardsToUnlock = deckCards.Take(2).ToList();

		foreach (var card in cardsToUnlock)
		{
			SoldierCardSO cardSO = card.DeckCardSO;
			if (cardSO.IsLocked() == true)
			{
				cardSO.SetCardLock(false);
				cardSO.SetSelectState(true);
				card.UpdateLockState();
				card.UpdateSelectState();
			}
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
