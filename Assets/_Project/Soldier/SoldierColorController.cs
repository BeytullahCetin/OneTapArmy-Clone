using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

public class SoldierColorController : MonoBehaviour
{
	[SerializeField] GameObject objectToChangeMaterialParent;
	SoldierHud soldierHud;

	private void Awake()
	{
		soldierHud = GetComponent<SoldierHud>();
	}

	public void ChangeColor(Material material, Color color)
	{
		List<Material> materials = new List<Material>();
		materials.Add(material);
		foreach (var renderer in objectToChangeMaterialParent.GetComponentsInChildren<SkinnedMeshRenderer>())
		{
			renderer.SetMaterials(materials);
		}

		soldierHud.HealthBar.fillRect.GetComponent<Image>().color = color;
	}
}
