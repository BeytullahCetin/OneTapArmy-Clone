using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
	[SerializeField] Button playButton;
	[SerializeField] Button backButton;
	[SerializeField] Transform home;
	[SerializeField] Transform levelSelection;
	[SerializeField] Transform levelCardsParent;

	public Button PlayButton => playButton;
	public Button BackButton => backButton;
	public Transform Home => home;
	public Transform LevelSelection => levelSelection;
	public Transform LevelCardsParent => levelCardsParent;
}
