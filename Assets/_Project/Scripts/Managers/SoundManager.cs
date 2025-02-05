using UnityEngine;
using Utility;

public class SoundManager : Singleton<SoundManager>
{
	public bool IsSFXActive => PlayerPrefs.GetInt(SFX_Enabled_PP, 1) == 1;
	public bool IsMusicActive => PlayerPrefs.GetInt(Music_Enabled_PP, 1) == 1;

	[SerializeField] SoundConfigSO config;
	[SerializeField] AudioSource sfxAudioSource;
	[SerializeField] AudioSource musicAudioSource;

	private const string SFX_Enabled_PP = "SFX_Enabled";
	private const string Music_Enabled_PP = "Music_Enabled";

	private void Start()
	{
		musicAudioSource.clip = config.gameBg;
		musicAudioSource.Play();

		SetSFXActive(IsSFXActive == true);
		SetMusicActive(IsMusicActive == true);
	}

	public void PlaySFX(AudioClip audioClip)
	{
		if (audioClip == null)
			return;

		sfxAudioSource.PlayOneShot(audioClip);
	}

	public void SetSFXActive(bool value)
	{
		PlayerPrefs.SetInt(SFX_Enabled_PP, value ? 1 : 0);
		sfxAudioSource.volume = value ? 1 : 0;
	}

	public void SetMusicActive(bool value)
	{
		PlayerPrefs.SetInt(Music_Enabled_PP, value ? 1 : 0);
		musicAudioSource.volume = value ? 1 : 0;
	}
}