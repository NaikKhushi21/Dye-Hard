using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFalling : MonoBehaviour
{
    public float fallingSpeed = 5.0f;
    public float lifeTime = 3.0f;  // Time in seconds before the obstacle disappears

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
            Debug.Log("Obstacle has disappeared: " + gameObject.name);
            // Here you can destroy the obstacle or deactivate it later.
            DestroyObstacle();  // This is where you'd later destroy the obstacle
        }
    }

    // For now, we'll just print a message to the console
    void DestroyObstacle()
    {
        Debug.Log("Destroying obstacle: " + gameObject.name);
        // Later you can uncomment the line below to actually destroy the object
        // Destroy(gameObject);
    }
}
