using NaughtyAttributes;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	[Expandable][SerializeField] LevelsSO levelsSO;
	public LevelsSO LevelsSO => levelsSO;

	int currentLevel = 1;
	public int CurrentLevel => currentLevel;

	public void LoadLevel()
	{
		if (PlayerPrefs.HasKey("Level") == false)
			PlayerPrefs.SetInt("Level", 1);

		currentLevel = PlayerPrefs.GetInt("Level", 1);
	}
}
