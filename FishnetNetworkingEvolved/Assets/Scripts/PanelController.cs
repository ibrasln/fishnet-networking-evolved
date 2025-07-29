using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : NetworkBehaviour
{
	[SerializeField] private Button backButton;
	private readonly SyncVar<bool> isVisible = new(false);

	private void Awake()
	{
		isVisible.OnChange += OnPanelVisibilityChanged;
	}

	private void Start()
	{
		backButton.onClick.AddListener(RequestTogglePanel);
	}

	private void OnDestroy()
	{
		backButton.onClick.RemoveListener(RequestTogglePanel);
	}

	public void RequestTogglePanel()
	{
		TogglePanel(!isVisible.Value);
	}

	[ServerRpc(RequireOwnership = false)]
	private void TogglePanel(bool newVisibility)
	{
		isVisible.Value = newVisibility;
	}

	private void OnPanelVisibilityChanged(bool oldValue, bool newValue, bool asServer)
	{
		if (isVisible.Value)
		{
			transform.localScale = Vector3.one;
		}
		else
		{
			transform.localScale = Vector3.zero;
		}
	}
}