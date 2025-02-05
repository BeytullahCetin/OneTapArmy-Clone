using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;

public class TowerSpawnController : MonoBehaviour
{
	[SerializeField] float spawnDuration = 1f;
	[SerializeField] Ease spawnEase = Ease.Linear;

	TowerHudController towerHudController;
	Tweener spawnTweener;

	bool isSpawningStarted;

	private void Awake()
	{
		towerHudController = GetComponent<TowerHudController>();
	}

	public void Initialize()
	{
		RestartSpawning();
	}

	[Button]
	public void UpdateSpawnDuration()
	{
		if (spawnTweener == null)
			return;

		spawnTweener.timeScale = 1 / spawnDuration;
	}

	async private void StartSpawning()
	{
		towerHudController.SpawnBar.fillAmount = 0; // Anında sıfırla
		isSpawningStarted = true;

		while (isSpawningStarted)
		{
			towerHudController.SpawnBar.fillAmount = 0;
			spawnTweener = towerHudController.SpawnBar
				.DOFillAmount(1, 1)
				.SetEase(spawnEase);

			spawnTweener.timeScale = 1 / spawnDuration;
			await spawnTweener;

			if (!isSpawningStarted)
				break;

			// Debug.Log("Spawn");
		}
	}

	private void StopSpwaning()
	{
		isSpawningStarted = false;
		if (spawnTweener != null && spawnTweener.IsActive())
		{
			spawnTweener.Kill(true);
		}
	}

	private void RestartSpawning()
	{
		StopSpwaning();
		StartSpawning();
	}
}