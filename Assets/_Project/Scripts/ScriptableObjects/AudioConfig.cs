using UnityEngine;

[CreateAssetMenu(fileName = "AudioConfigSO", menuName = "ScriptableObjects/AudioConfigSO")]
public class SoundConfigSO : ScriptableObject
{
	public AudioClip menuBg;
	public AudioClip gameBg;

	public AudioClip primaryButtonClick;
	public AudioClip secondaryButtonClick;
	public AudioClip succesButtonClick;
	public AudioClip infoButtonClick;
	public AudioClip warningButtonClick;
	public AudioClip dangerButtonClick;

	public AudioClip levelUp;
	public AudioClip xpGain;
	public AudioClip towerHit;
	public AudioClip towerCollapse;

	public AudioClip soldierCreated;
	public AudioClip soldierDeath;

	public AudioClip soldierSwordHit;
	public AudioClip soldierAxeHit;
	public AudioClip soldierArrowHit;
	public AudioClip soldierStep;
}
