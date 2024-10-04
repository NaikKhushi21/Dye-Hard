using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ObstacleWrapperPrefab;

    private float spawnPosY = 7;
    private float spawnPosXRange = 10;
    private LevelManager levelManager;
    private ObstacleManager obstacleManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        obstacleManager = FindObjectOfType<ObstacleManager>();
        Invoke("SpawnRandomObstacle", obstacleManager.GetSpawnInterval());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRandomObstacle()
    {
        Color randomColor = GetRandomColor();
        Vector2 spawnPos = new Vector2(Random.Range(-spawnPosXRange, spawnPosXRange), spawnPosY);
        Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);
        GameObject instantiatedWrapper = Instantiate(ObstacleWrapperPrefab, spawnPos, spawnRotation);

        GameObject obstacle = ObstacleWrapperManager.GetObstacle(instantiatedWrapper);
        obstacle.GetComponent<Renderer>().material.color = randomColor;

        // Schedule the next spawn
        Invoke("SpawnRandomObstacle", obstacleManager.GetSpawnInterval());
    }

    Color GetRandomColor()
    {
        int currentLevel = levelManager.currentLevel;
        if (currentLevel == 1)
        {
            return GetRandomPrimaryColor();
        }
        else
        {
            return GetRandomAllColor();
        }
        
    }

    Color GetRandomPrimaryColor()
    {
        int randomIndex = Random.Range(0, ColorManager.PrimaryColors.Count);
        return ColorManager.PrimaryColors[randomIndex];
    }

    Color GetRandomAllColor()
    {
        int randomIndex = Random.Range(0, ColorManager.AllColors.Count);
        return ColorManager.AllColors[randomIndex];
    }
}
