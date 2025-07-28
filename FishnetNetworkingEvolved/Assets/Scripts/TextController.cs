using FishNet.Object;
using FishNet.Object.Synchronizing;
using TMPro;
using UnityEngine;

public class TextController : NetworkBehaviour
{
	private TextMeshProUGUI _text;
	public readonly SyncVar<int> number = new();

	private void Awake()
	{
		_text = GetComponent<TextMeshProUGUI>();
		number.Value = 0;
		number.OnChange += OnNumberChanged;
	}

	private void OnNumberChanged(int oldValue, int newValue, bool asServer)
	{
		_text.text = number.Value.ToString();
	}

	public void IncreaseNumber()
	{
		number.Value++;
	}

	public void DecreaseNumber()
	{
		number.Value--;
	}

}