using UnityEngine;
using Unity.Netcode;

public class PlayerSpawner : NetworkBehaviour
{
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    public override void OnNetworkSpawn()
    {
        if (!IsServer) return;

        foreach (var client in NetworkManager.Singleton.ConnectedClientsList)
        {
            SpawnPlayer(client.ClientId);
        }

        NetworkManager.Singleton.OnClientConnectedCallback += SpawnPlayer;
    }

    void SpawnPlayer(ulong clientId)
    {
        Transform spawnPoint = clientId == 0 ? spawnPoint1 : spawnPoint2;

        NetworkObject playerObj = NetworkManager.Singleton.SpawnManager
            .GetLocalPlayerObject();

        if (playerObj != null)
        {
            playerObj.transform.position = spawnPoint.position;
        }
    }

    public override void OnNetworkDespawn()
    {
        NetworkManager.Singleton.OnClientConnectedCallback -= SpawnPlayer;
    }
}