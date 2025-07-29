using System;
using System.Collections;
using System.Linq;
using FishNet.Object;
using UnityEngine;

public class UIManager : NetworkSingleton<UIManager>
{
	[SerializeField] private GameObject notificationPanel;

	// Called locally on any client
	public void OnNotificationButtonClicked()
	{
		// This just routes the call to the server
		SendNotificationRequestServerRpc();
	}

	// ServerRpc — gets triggered from client, runs on server
	[ServerRpc(RequireOwnership = false)]
	private void SendNotificationRequestServerRpc()
	{
		// Server broadcasts to all clients (including original sender)
		ShowNotificationObserversRpc();
	}

	// ObserversRpc — runs on all clients
	[ObserversRpc]
	private void ShowNotificationObserversRpc()
	{
		if (notificationPanel != null)
			notificationPanel.SetActive(true);
	}

	// Optional: Hide the panel again later
	[ObserversRpc]
	public void HideNotificationObserversRpc()
	{
		if (notificationPanel != null)
			notificationPanel.SetActive(false);
	}
}