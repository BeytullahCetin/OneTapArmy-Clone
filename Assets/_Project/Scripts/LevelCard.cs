using FormatableTextNS;
using UnityEngine;
using UnityEngine.UI;

public class LevelCard : MonoBehaviour
{
	[SerializeField] GameObject locked;
	[SerializeField] GameObject unlocked;
	[SerializeField] FormatableText levelText;
	[SerializeField] Button playButton;

	public GameObject Locked => locked;
	public GameObject Unlocked => unlocked;
	public FormatableText LevelText => levelText;
	public Button PlayButton => playButton;
}
