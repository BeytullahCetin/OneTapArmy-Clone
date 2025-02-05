using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
	[SerializeField] Button settingsButton;
	[SerializeField] SettingsPanel settingsPanel;
	[SerializeField] MainMenuManager mainMenuManager;

	private void Start()
	{
		settingsPanel.gameObject.SetActive(false);

		settingsButton.onClick.AddListener(OpenSettingsPanel);
		settingsPanel.CloseButtons.ForEach(x => x.onClick.AddListener(CloseSettingsPanel));

		settingsPanel.SfxToggle.Initialize(SoundManager.instance.IsSFXActive == true ? 1 : 0);
		settingsPanel.MusicToggle.Initialize(SoundManager.instance.IsMusicActive == true ? 1 : 0);
		settingsPanel.VibrationToggle.Initialize(0);
		// vibrationToggle.Initialize(VibrationManager.instance.IsVibrationActive == true ? 1 : 0);

		settingsPanel.SfxToggle.OnToggleChange.AddListener(OnSfxToggleChange);
		settingsPanel.MusicToggle.OnToggleChange.AddListener(OnMusicToggleChange);
		settingsPanel.VibrationToggle.OnToggleChange.AddListener(OnVibrationToggleChange);
	}

	private void OnSfxToggleChange()
	{
		Debug.Log("SFX Toggle Changed!");
		SoundManager.instance.SetSFXActive(settingsPanel.SfxToggle.CurrentIndex == 1);
		Debug.Log($"New toggle index: {settingsPanel.SfxToggle.CurrentIndex}");
	}

	private void OnMusicToggleChange()
	{
		Debug.Log("Music Toggle Changed!");
		SoundManager.instance.SetMusicActive(settingsPanel.MusicToggle.CurrentIndex == 1);
		Debug.Log($"New toggle index: {settingsPanel.MusicToggle.CurrentIndex}");
	}

	private void OnVibrationToggleChange()
	{
		Debug.Log("Vibration Toggle Changed!");
		Debug.Log($"New toggle index: {settingsPanel.VibrationToggle.CurrentIndex}");
	}

	public void OpenSettingsPanel()
	{
		settingsPanel.HomeButton.gameObject.SetActive(!mainMenuManager.IsMainMenu);
		settingsPanel.gameObject.SetActive(true);
	}

	public void CloseSettingsPanel()
	{
		settingsPanel.gameObject.SetActive(false);
	}
}
