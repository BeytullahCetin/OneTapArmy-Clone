using FormatableTextNS;
using UnityEngine;
using UnityEngine.UI;

public class TowerHudController : MonoBehaviour
{
	[SerializeField] Slider healthBar;
	[SerializeField] Image spawnBar;

	[SerializeField] FormatableText health;
	[SerializeField] FormatableText level;

	public Slider HealthBar => healthBar;
	public Image SpawnBar => spawnBar;

	public FormatableText Health => health;
	public FormatableText Level => level;

}
