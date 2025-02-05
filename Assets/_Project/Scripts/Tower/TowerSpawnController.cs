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


	private void Awake()
	{
		towerHudController = GetComponent<TowerHudController>();
	}

	public void Initialize()
	{
		towerHudController.SpawnBar.fillAmount = 0;
		towerHudController.SpawnBar.fillAmount = 1;
		StartSpawning();
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
		while (true)
		{
			towerHudController.SpawnBar.fillAmount = 0;
			spawnTweener = towerHudController.SpawnBar
				.DOFillAmount(1, 1)
				.SetEase(spawnEase);

			spawnTweener.timeScale = 1 / spawnDuration;
			await spawnTweener;

			// Debug.Log("Spawn");
		}
	}
}