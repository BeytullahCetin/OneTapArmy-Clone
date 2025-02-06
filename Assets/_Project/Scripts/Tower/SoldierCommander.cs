using System.Linq;
using UnityEngine;

public class SoldierCommander : MonoBehaviour
{
	[SerializeField] LayerMask commandRayLayerMask;
	[SerializeField] float maxRayDistance = 1000f;

	Camera mainCam;
	RaycastHit[] hits;

	TowerSoldierController towerSoldierController;

	private void Awake()
	{
		towerSoldierController = GetComponent<TowerSoldierController>();
		mainCam = Camera.main;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
			CommandSoldiers();
	}

	public void CommandSoldiers()
	{
		Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
		hits = Physics.RaycastAll(ray, maxRayDistance, commandRayLayerMask);

		if (hits.Length <= 0)
			return;

		RaycastHit hit = hits.OrderBy(x => (x.point - ray.origin).sqrMagnitude).First();


		Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.red, 2f);
		Debug.Log($"Ray Hit! - {LayerMask.LayerToName(hit.transform.gameObject.layer)}");

		EnemyTower enemyTower;
		Soldier soldier;


		if (hit.collider.TryGetComponent(out enemyTower))
		{
			towerSoldierController.Soldiers.ForEach(x => x.Attack(enemyTower.Tower.TowerHealth));
		}
		else if (hit.collider.TryGetComponent(out soldier))
		{
			towerSoldierController.Soldiers.ForEach(x => x.Attack(soldier.SoldierHealth));
		}
		else
		{
			towerSoldierController.Soldiers.ForEach(x => x.Move(hit.point));
		}
	}
}
