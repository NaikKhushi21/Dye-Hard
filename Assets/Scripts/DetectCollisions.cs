using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("Ball"))
        {
            HandleBallCollision();
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            HandleObstacleCollision(other);
        }
    }

    void HandleBallCollision()
    {
        Destroy(gameObject);
    }

    void HandleObstacleCollision(Collider2D other)
    {
        Color obstacleColor = gameObject.GetComponent<Renderer>().material.color;
        Color ballColor = other.gameObject.GetComponent<Renderer>().material.color;
        if (ColorManager.PrimaryColorsSet.Contains(obstacleColor))
        {
            HandlePrimaryColorCollision(obstacleColor, ballColor);
        }
        else
        {
            HandleBlendedColorCollision(obstacleColor, ballColor);
        }
    }

    void HandlePrimaryColorCollision(Color obstacleColor, Color ballColor)
    {
        if (obstacleColor == ballColor)
        {
            // TODO: give player rewards
            Debug.Log("color matches");
            Destroy(gameObject);
        }
        else
        {
            // TODO: give player penalty
            Debug.Log("color didn't match");
            Destroy(gameObject);
        }
    }

    void HandleBlendedColorCollision(Color obstacleColor, Color ballColor)
    {
        // TODO: change color based on what current obstacleColor and ballColor is
        Destroy(gameObject);
    }
}
