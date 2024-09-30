
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ObstaclePrefab;

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
        GameObject newObstacle = ObstaclePrefab;
        // Pick a random color from ColorManager
        Color randomColor = GetRandomColor();

        Vector2 spawnPos = new Vector2(Random.Range(-spawnPosXRange, spawnPosXRange), spawnPosY);
        Quaternion spawnRotaton = Quaternion.Euler(0, 0, 0);

        GameObject instantiatedObstacle = Instantiate(newObstacle, spawnPos, spawnRotaton);
        instantiatedObstacle.GetComponent<Renderer>().material.color = randomColor;

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
