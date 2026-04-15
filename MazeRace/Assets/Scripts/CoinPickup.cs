using UnityEngine;
using Unity.Netcode;

public class CoinPickup : NetworkBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!IsServer) return;

        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddScore(10);
            DespawnCoin();
        }
    }

    void DespawnCoin()
    {
        GetComponent<NetworkObject>().Despawn();
    }
}