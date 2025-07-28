using FishNet.Object;
using UnityEngine;

public class ObjectSpawner : NetworkBehaviour
{
	[SerializeField] private NetworkObject objectToSpawn;

	private void Update()
	{
		// Only the local player object should perform these actions.
		if (!IsOwner) return;

		if (Input.GetKeyDown(KeyCode.Space))
		{
			SpawnObject();
		}
	}

	// We are using a ServerRpc here because the Server needs to do all network object spawning.
	[ServerRpc]
	private void SpawnObject()
	{
		NetworkObject networkObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
		Spawn(networkObject); // NetworkBehaviour shortcut for ServerManager.Spawn(obj);
	}
}