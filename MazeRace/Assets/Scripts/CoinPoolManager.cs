using UnityEngine;
using System.Collections.Generic;

public class CoinPoolManager : MonoBehaviour
{
    public static CoinPoolManager Instance { get; private set; }

    public GameObject coinPrefab;

    private ObjectPool coinPool;
    private List<Vector3> coinStartPositions;
    private List<GameObject> activeCoins;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        // Find all spawn points by tag and record positions
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("coin");
        coinStartPositions = new List<Vector3>();

        foreach (GameObject spawn in spawnPoints)
        {
            coinStartPositions.Add(spawn.transform.position);
            // Don't destroy them - they are just markers
        }

        coinPool = new ObjectPool(coinPrefab, coinStartPositions.Count);
        activeCoins = new List<GameObject>();
        SpawnAllCoins();
    }

    public void SpawnAllCoins()
    {
        foreach (Vector3 position in coinStartPositions)
        {
            GameObject coin = coinPool.Get();
            coin.transform.position = position;
            activeCoins.Add(coin);
        }
    }

    public void ReturnCoin(GameObject coin)
    {
        coinPool.Return(coin);
        activeCoins.Remove(coin);

        if (activeCoins.Count == 0)
        {
            GameManager.Instance.TriggerGameOver("All coins collected!");
        }
    }

    public void ResetAllCoins()
    {
        foreach (GameObject coin in activeCoins)
        {
            coinPool.Return(coin);
        }
        activeCoins.Clear();
        SpawnAllCoins();
    }
}