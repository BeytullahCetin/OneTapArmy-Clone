using System;
using System.Collections.Generic;
using System.Linq;
using NaughtyAttributes;
using UnityEngine;

public class TowerModelController : MonoBehaviour
{
	[SerializeField] List<TowerModel> towerModels = new List<TowerModel>();
	[SerializeField] Material material;

	TowerModel currentTowerModel;
	TowerLevelController towerLevelController;

	private void Awake()
	{
		towerLevelController = GetComponent<TowerLevelController>();
	}

	public void Initialize()
	{
		UpdateModel();
	}

	public TowerModel GetTowerModelLevel(int level)
	{
		// Assume towerModelLevels are pre sorted by designer/developer.
		// and list is not empty
		// var modelLevels = towerModelLevels.Where(x => x.levelUntil == -1 || x.levelUntil >= level).OrderBy(x => x.levelUntil).ToList();

		var filteredModels = towerModels.SkipWhile(x => x.levelUntil > 0 && level > x.levelUntil).OrderBy(x => x.levelUntil).ToList();

		if (filteredModels.Count >= 2)
			return filteredModels[1];
		return filteredModels[0];
	}

	[Button]
	public void UpdateModel()
	{
		currentTowerModel = GetTowerModelLevel(towerLevelController.Level);
		DisableAllTowerModels();
		EnableTowerModel(currentTowerModel);
	}

	[Button]
	public void DisableAllTowerModels()
	{
		foreach (var towerModelLevel in towerModels)
		{
			towerModelLevel.model.gameObject.SetActive(false);
		}
	}

	public void EnableTowerModel(TowerModel towerModelLevel)
	{
		towerModelLevel.model.gameObject.SetActive(true);
	}

	[Button]
	public void UpdateMaterial()
	{
		List<Material> materials = new List<Material>();
		materials.Add(material);
		foreach (var towerModel in towerModels)
		{
			foreach (var meshRenderer in towerModel.model.GetComponentsInChildren<MeshRenderer>())
			{
				meshRenderer.SetMaterials(materials);
			}
		}
	}
}

[Serializable]
public class TowerModel
{
	public GameObject model;
	public int levelUntil;

	public override string ToString()
	{
		return $"{model.name} - {levelUntil}";
	}
}
