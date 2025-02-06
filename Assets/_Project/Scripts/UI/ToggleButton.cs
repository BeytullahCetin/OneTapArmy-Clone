using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
	public UnityEvent OnToggleChange => onToggleChange;
	public int CurrentIndex => currentIndex;

	[SerializeField] Button button;
	[SerializeField] GameObject[] selections;
	[SerializeField] UnityEvent onToggleChange;

	private int currentIndex;

	public void Initialize(int startIndex)
	{
		if (startIndex < 0 || startIndex >= selections.Length)
			return;

		currentIndex = startIndex;
		UpdateSelections();
		button.onClick.AddListener(OnButtonClick);
	}

	private void OnButtonClick()
	{
		currentIndex = (currentIndex + 1) % selections.Length;
		UpdateSelections();

		onToggleChange.Invoke();
	}

	void UpdateSelections()
	{
		DisableAllSelections();
		selections[currentIndex].SetActive(true);
	}

	private void DisableAllSelections()
	{
		foreach (var selection in selections)
		{
			selection.SetActive(false);
		}
	}
}
