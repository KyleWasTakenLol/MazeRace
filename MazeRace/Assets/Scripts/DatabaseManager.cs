using UnityEngine;
using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class HighScore
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string PlayerName { get; set; }
    public float CompletionTime { get; set; }
}

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager Instance { get; private set; }

    private string dbPath;
    private SQLiteConnection dbConnection;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        SetDatabasePath();
        InitializeDatabase();
    }

    void SetDatabasePath()
    {
        dbPath = Path.Combine(Application.persistentDataPath, "mazerace.db");
    }

    void InitializeDatabase()
    {
        dbConnection = new SQLiteConnection(dbPath);
        dbConnection.CreateTable<HighScore>();
        Debug.Log("Database initialized at: " + dbPath);
    }

    public void SaveHighScore(string playerName, float completionTime)
    {
        HighScore newScore = new HighScore
        {
            PlayerName = playerName,
            CompletionTime = completionTime
        };

        dbConnection.Insert(newScore);
        Debug.Log("Score saved: " + playerName + " - " + completionTime + "s");
    }

    public List<HighScore> GetTopHighScores(int count)
    {
        return dbConnection.Table<HighScore>()
            .OrderBy(score => score.CompletionTime)
            .Take(count)
            .ToList();
    }
}