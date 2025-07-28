using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine;

public class ColorChanger : NetworkBehaviour
{
    public readonly SyncVar<Color> color = new();
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        color.OnChange += OnColorChanged;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor();
        }
    }

    [ServerRpc]
    private void ChangeColor()
    {
        color.Value = Random.ColorHSV();
    }

    private void OnColorChanged(Color oldColor, Color newColor, bool asServer)
    {
        _spriteRenderer.color = color.Value;
    }

}
