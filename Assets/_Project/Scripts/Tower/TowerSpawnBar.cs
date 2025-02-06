using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using NaughtyAttributes;
using UnityEngine.Events;

public class TowerSpawnBar : MonoBehaviour
{
	public UnityEvent SpawnEvent { get; private set; }
	public UnityEvent RestartSpawningEvent { get; private set; }

	[SerializeField] float spawnDuration = 1f;
	[SerializeField] Ease spawnEase = Ease.Linear;

	TowerHudController towerHudController;
	Tweener spawnTweener;

	bool isSpawningStarted;

	private void Awake()
	{
		towerHudController = GetComponent<TowerHudController>();
		SpawnEvent = new UnityEvent();
		RestartSpawningEvent = new UnityEvent();
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

			SpawnEvent.Invoke();
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
		RestartSpawningEvent.Invoke();
	}
}