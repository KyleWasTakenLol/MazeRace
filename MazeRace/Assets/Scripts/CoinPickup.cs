using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private bool collected = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;

        if (other.CompareTag("Player"))
        {
            collected = true;
            GameManager.Instance.AddScore(10);
            CoinPoolManager.Instance.ReturnCoin(gameObject);
        }
    }
}