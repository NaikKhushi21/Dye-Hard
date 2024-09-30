/*
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
*/

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    public GameObject TimerUIPrefab; // Timer UI prefab

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
        Vector2 spawnPos = new Vector2(Random.Range(-spawnPosXRange, spawnPosXRange), spawnPosY);
        Quaternion spawnRotaton = Quaternion.Euler(0, 0, 0);

        GameObject newObstacle = Instantiate(ObstaclePrefab, spawnPos, spawnRotaton);

        // Set a random color for the obstacle
        newObstacle.GetComponent<Renderer>().material.color = GetRandomColor();

        // Spawn the timer UI and attach it to the obstacle
        GameObject timerUI = Instantiate(TimerUIPrefab, newObstacle.transform);
        timerUI.transform.position = new Vector3(spawnPos.x, spawnPos.y + 1.5f, spawnPos.z); // Adjust position above obstacle

        // Assign a timer duration and start the countdown
        float timerDuration = Random.Range(5f, 10f); // Example duration
        timerUI.GetComponent<ObstacleTimer>().StartTimer(timerDuration);

        Invoke("SpawnRandomObstacle", Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    Color GetRandomColor()
    {
        int randomIndex = Random.Range(0, ColorManager.AllColors.Count);
        return ColorManager.AllColors[randomIndex];
    }
}
