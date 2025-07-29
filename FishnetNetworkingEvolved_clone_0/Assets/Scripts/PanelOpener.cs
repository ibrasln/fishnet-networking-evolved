using System;
using System.Collections;
using System.Linq;
using FishNet.Object;
using UnityEngine;
using UnityEngine.UI;

public class PanelOpener : NetworkBehaviour
{
	private PanelController _panel;
	private Button _openButton;

	public override void OnStartClient()
	{
		_panel = FindObjectOfType<PanelController>(true);
		if (_panel == null)
		{
			Debug.LogError("PanelController not found");
		}
		else
		{
			Debug.Log($"Successfully found PanelController: {_panel.gameObject.name}");
		}
		_openButton = GameObject.Find("Button_Open").GetComponent<Button>();
		_openButton.onClick.AddListener(TogglePanel);
	}

	public override void OnStopClient()
	{
		_openButton.onClick.RemoveListener(TogglePanel);
	}

	private void TogglePanel()
	{
		_panel.RequestTogglePanel();
	}
}