using FishNet.Object;
using UnityEngine;
using UnityEngine.UI;

public class NumberChanger : NetworkBehaviour
{
	private TextController _textController;
	private Button _decreaseButton;
	private Button _increaseButton;

	public override void OnStartClient()
	{
		Debug.Log("OnStartClient called by " + base.Owner);
		_textController = FindObjectOfType<TextController>();
		if (_textController == null)
			Debug.LogError("TextController not found");
		else
			Debug.Log($"Successfully found TextController: {_textController.gameObject.name}");

		_decreaseButton = GameObject.Find("Button_Decrease").GetComponent<Button>();
		_increaseButton = GameObject.Find("Button_Increase").GetComponent<Button>();

		_decreaseButton.onClick.AddListener(DecreaseNumber);
		_increaseButton.onClick.AddListener(IncreaseNumber);
	}

	public override void OnStopClient()
	{
		_decreaseButton.onClick.RemoveListener(DecreaseNumber);
		_increaseButton.onClick.RemoveListener(IncreaseNumber);
	}

	[ServerRpc(RequireOwnership = false)]
	public void IncreaseNumber()
	{
		if (!IsOwner) return;
		_textController.IncreaseNumber();
	}

	[ServerRpc(RequireOwnership = false)]
	public void DecreaseNumber()
	{
		if (!IsOwner) return;
		_textController.DecreaseNumber();
	}

	private void Update()
	{
		if (!IsOwner) return;
	}
}