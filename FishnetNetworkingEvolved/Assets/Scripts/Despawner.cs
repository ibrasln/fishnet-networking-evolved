using System.Collections;
using FishNet.Object;
using UnityEngine;

public class Despawner : NetworkBehaviour
{
	private float _secondsToDespawn = 2f;

	public override void OnStartServer()
	{
		StartCoroutine(DespawnRoutine());
	}

	private IEnumerator DespawnRoutine()
	{
		yield return new WaitForSeconds(_secondsToDespawn);
		Despawn();// NetworkBehaviour shortcut for ServerManager.Despawn(gameObject);
	}
}