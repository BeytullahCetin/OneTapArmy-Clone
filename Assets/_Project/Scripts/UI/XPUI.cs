using DG.Tweening;
using FormatableTextNS;
using UnityEngine;
using UnityEngine.UI;

public class XPUI : MonoBehaviour
{
	[SerializeField] Slider xpBar;
	[SerializeField] FormatableText xpText;

	[SerializeField] Transform levelMarkerTransform;
	[SerializeField] FormatableText levelText;

	public Slider XpBar => xpBar;

	Tweener xpBarTween;

	public void UpdateXPUI(int currentLevel, float currentLevelXp, float requiredXp)
	{
		xpBar.minValue = 0;
		xpBar.maxValue = requiredXp;

		if (xpBarTween != null)
			DOTween.Kill(xpBarTween);

		xpBarTween = xpBar.DOValue(currentLevelXp, 1);
		xpText.FillText(currentLevelXp.ToString(), requiredXp.ToString());

		levelText.FillText(currentLevel.ToString());
	}
}
