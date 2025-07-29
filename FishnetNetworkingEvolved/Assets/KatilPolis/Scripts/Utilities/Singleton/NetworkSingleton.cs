using UnityEngine;
using FishNet.Object;

[DefaultExecutionOrder(-5)]
public abstract class NetworkSingleton<T> : NetworkBehaviour where T : NetworkBehaviour
{
    public static T Instance { get; private set; }

    public override void OnStartNetwork()
    {
        base.OnStartNetwork();

        if (Instance == null)
        {
            Instance = this as T;
        }
        else if (Instance != this)
        {
            Debug.LogError($"[NetworkMonoSingleton] Duplicate instance of {typeof(T).Name} detected. Destroying this.");

            if (IsServerInitialized)
                Despawn();
            else
                Destroy(gameObject);
        }
    }

    public override void OnStopNetwork()
    {
        base.OnStopNetwork();

        if (Instance == this)
            Instance = null;
    }
}
