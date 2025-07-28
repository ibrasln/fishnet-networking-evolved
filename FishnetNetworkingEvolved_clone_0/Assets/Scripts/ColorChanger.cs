using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine;

public class ColorChanger : NetworkBehaviour
{
    // SyncVars are used to synchronize a single field. Your field can be virtually anything: a value type, struct, or class.
    public readonly SyncVar<Color> color = new();
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        color.OnChange += OnColorChanged;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    [ServerRpc]
    private void ChangeColor()
    {
        color.Value = Random.ColorHSV();
    }

    /// <summary>
    /// Each callback for SyncVars must contain a parameter for the previous value, the next value, and asServer.
    /// </summary>
    /// <param name="oldColor">The previous value will contain the value before the change.</param>
    /// <param name="newColor">The next value contains the value after the change.</param>
    /// <param name="asServer">Indicates if the callback is occurring on the server or on the client.</param>
    private void OnColorChanged(Color oldColor, Color newColor, bool asServer)
    {
        _spriteRenderer.color = color.Value;
    }

}
