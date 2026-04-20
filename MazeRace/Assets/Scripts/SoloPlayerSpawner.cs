using UnityEngine;

public class SoloPlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;

    void Start()
    {
        GameObject player = Instantiate(playerPrefab, 
            spawnPoint.position, Quaternion.identity);
    }
}