using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
	[SerializeField] List<Button> closeButtons = new List<Button>();
	[SerializeField] Button homeButton;
	[SerializeField] ToggleButton sfxToggle;
	[SerializeField] ToggleButton musicToggle;
	[SerializeField] ToggleButton vibrationToggle;

	public List<Button> CloseButtons => closeButtons;
	public Button HomeButton => homeButton;
	public ToggleButton SfxToggle => sfxToggle;
	public ToggleButton MusicToggle => musicToggle;
	public ToggleButton VibrationToggle => vibrationToggle;
}
