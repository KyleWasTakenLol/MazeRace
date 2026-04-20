using UnityEngine;
using Unity.Netcode;

public class PlayerSpawner : NetworkBehaviour
{
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public GameObject playerPrefab;

    public override void OnNetworkSpawn()
    {
        if (!IsServer) return;
        
        // Spawn host player immediately
        SpawnPlayerForClient(NetworkManager.Singleton.LocalClientId);
        
        // Listen for future client connections
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnected;
    }

    void OnClientConnected(ulong clientId)
    {
        if (!IsServer) return;
        SpawnPlayerForClient(clientId);
    }

    void SpawnPlayerForClient(ulong clientId)
    {
        Transform spawnPoint = clientId == 0 ? spawnPoint1 : spawnPoint2;

        GameObject player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        NetworkObject networkObject = player.GetComponent<NetworkObject>();
        networkObject.SpawnAsPlayerObject(clientId);
    }

    public override void OnNetworkDespawn()
    {
        if (NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.OnClientConnectedCallback -= OnClientConnected;
        }
    }
}