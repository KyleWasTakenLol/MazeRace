using UnityEngine;
using Unity.Netcode;

public class CoinSpawner : NetworkBehaviour
{
    public GameObject coinPrefab;
    public Transform[] spawnPoints;

    public override void OnNetworkSpawn()
    {
        if (!IsServer) return;
        SpawnCoins();
    }

    void SpawnCoins()
    {
        foreach (Transform point in spawnPoints)
        {
            GameObject coin = Instantiate(coinPrefab, point.position, Quaternion.identity);
            coin.GetComponent<NetworkObject>().Spawn();
        }
    }
}