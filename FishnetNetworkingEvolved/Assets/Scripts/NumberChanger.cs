using FishNet.Object;
using UnityEngine;

public class NumberChanger : NetworkBehaviour
{
	private TextController _textController;

	public override void OnStartClient()
	{
		Debug.Log("OnStartClient called by " + base.Owner);
		_textController = FindObjectOfType<TextController>();
		if (_textController == null)
			Debug.LogError("TextController not found");
		else
			Debug.Log($"Successfully found TextController: {_textController.gameObject.name}");
	}

	private void Update()
	{
		if (!IsOwner) return;
		if (Input.GetKeyDown(KeyCode.UpArrow))
			IncreaseNumber();
		if (Input.GetKeyDown(KeyCode.DownArrow))
			DecreaseNumber();
	}

	[ServerRpc]
	public void IncreaseNumber()
	{
		_textController.IncreaseNumber();
	}

	[ServerRpc]
	public void DecreaseNumber()
	{
		_textController.DecreaseNumber();
	}
}