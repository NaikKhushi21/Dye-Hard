using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ObstacleWrapperPrefab;

    private float spawnPosY = 7;
    private float spawnPosXRange = 10;

    private float minSpawnInterval = 1.0f;
    private float maxSpawnInterval = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnRandomObstacle", Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRandomObstacle()
    {
        // Pick a random color from ColorManager
        Color randomColor = GetRandomColor();

        Vector2 spawnPos = new Vector2(Random.Range(-spawnPosXRange, spawnPosXRange), spawnPosY);
        Quaternion spawnRotation = Quaternion.Euler(0, 0, 0);

        // Instantiate the wrapper
        GameObject instantiatedWrapper = Instantiate(ObstacleWrapperPrefab, spawnPos, spawnRotation);

        // Find the actual obstacle GameObject inside the wrapper
        //GameObject obstacle = instantiatedWrapper.transform.Find("Obstacle").gameObject;
        GameObject obstacle = ObstacleWrapperManager.GetObstacle(instantiatedWrapper);

        // Set the random color on the obstacle's material
        obstacle.GetComponent<Renderer>().material.color = randomColor;

        // Schedule the next spawn
        Invoke("SpawnRandomObstacle", Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    Color GetRandomColor()
    {
        // Choose a random index from the AllColors list
        int randomIndex = Random.Range(0, ColorManager.AllColors.Count);

        // Return the randomly chosen color
        return ColorManager.AllColors[randomIndex];
    }
}
