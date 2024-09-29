using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFalling : MonoBehaviour
{
    public float fallingSpeed = 5.0f;
    private float minLifeTime = 3.0f;  // Minimum lifetime for an obstacle
    private float maxLifeTime = 7.0f; // Maximum lifetime for an obstacle
    private float lifeTime;           // Actual lifetime for this specific

    

    // Start is called before the first frame update
    void Start()
    {
        // Assign a random lifetime between minLifeTime and maxLifeTime
        lifeTime = Random.Range(minLifeTime, maxLifeTime);


        // Log the lifetime for debugging
        Debug.Log("Obstacle " + gameObject.name + " lifetime: " + lifeTime + " seconds");

        

    }

    // Update is called once per frame
    void Update()
    {
        // Move the obstacle down
        transform.Translate(Vector3.down * fallingSpeed * Time.deltaTime);

        // Decrease the lifeTime timer
        lifeTime -= Time.deltaTime;

        // Check if the timer has run out
        if (lifeTime <= 0)
        {
            // Debug.Log("Obstacle has disappeared: " + gameObject.name);
            DestroyObstacle();
        }



    }

    // For now, we'll just print a message to the console
    void DestroyObstacle()
    {
        // Debug.Log("Destroying obstacle: " + gameObject.name);
        // Later you can uncomment the line below to actually destroy the object
        Destroy(gameObject);
    }
}
