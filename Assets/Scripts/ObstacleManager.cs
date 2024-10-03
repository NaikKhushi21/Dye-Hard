using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private (float, float) DEFAULT_TIME_RANGE = (4.0f, 8.0f);
    private List<float> DEFAULT_FALLING_SPEED = new() { 2.0f, 2.5f, 3.0f };
    private (float, float) DEFAULT_SPAWN_INTERVAL = (1.5f, 3.0f);
    private Dictionary<int, (float minLifeTime, float maxLifeTime)> levelLifetimeMapping;
    private Dictionary<int, List<float>> levelFallingSpeedMapping;
    private Dictionary<int, (float minSpawnInterval, float maxSpawnInterval)> levelSpawnIntervalMapping;

    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        levelLifetimeMapping = new Dictionary<int, (float minLifeTime, float maxLifeTime)>
        {
            { 1, DEFAULT_TIME_RANGE },
            { 2, (3.5f, 6.0f) },
            { 3, (2.5f, 4.0f) },
        };
        levelFallingSpeedMapping = new Dictionary<int, List<float>>
        {
            { 1, DEFAULT_FALLING_SPEED }, 
            { 2, new List<float> { 3.0f, 4.0f, 5.0f } }, 
            { 3, new List<float> { 5.0f, 6.0f, 7.0f } },
        };
        levelSpawnIntervalMapping = new Dictionary<int, (float minSpawnInterval, float maxSpawnInterval)>
        {
            { 1, (1.5f, 3.0f) },
            { 2, (1.0f, 2.0f) },
            { 3, (0.5f, 1.0f) },
        };
    }

    private void Update()
    {
        
    }

    // Method to get the lifetime range based on the current level
    public float GetLifeTime()
    {
        int currentLevel = levelManager.currentLevel;

        if (levelLifetimeMapping.ContainsKey(currentLevel))
        {
            var (minLifeTime, maxLifeTime) = levelLifetimeMapping[currentLevel];
            return Random.Range(minLifeTime, maxLifeTime);
        }
        var (defaultMinLifeTime, defaultMaxLifeTime) = DEFAULT_TIME_RANGE;
        return Random.Range(defaultMinLifeTime, defaultMaxLifeTime);
    }

    public float GetFallingSpeed()
    {
        int currentLevel = levelManager.currentLevel;
        if (levelFallingSpeedMapping.ContainsKey(currentLevel)){
            List<float> fallingSpeeds = levelFallingSpeedMapping[currentLevel];

            int randomIndex = Random.Range(0, fallingSpeeds.Count);
            return fallingSpeeds[randomIndex];
        }
        return DEFAULT_FALLING_SPEED[0];
    }

    public float GetSpawnInterval()
    {
        int currentLevel = levelManager.currentLevel;
        if (levelSpawnIntervalMapping.ContainsKey(currentLevel))
        {
            var (minSpawnInterval, maxSpawnInterval) = levelSpawnIntervalMapping[currentLevel];
            return Random.Range(minSpawnInterval, maxSpawnInterval);
        }
        var (defaultMinSpawnInterval, defaultMaxSpawnInterval) = DEFAULT_SPAWN_INTERVAL;
        return Random.Range(defaultMinSpawnInterval, defaultMaxSpawnInterval);
    }
}