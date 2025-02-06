using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "SoldierDB", menuName = "ScriptableObjects/SoldierDB")]

public class SoldierDB : ScriptableObject
{
	[Expandable][SerializeField] List<SoldierCardSO> soldiers = new List<SoldierCardSO>();
	public List<SoldierCardSO> SoldierCards => soldiers;
}
