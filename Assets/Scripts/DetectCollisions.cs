using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private int rewardBall = 3;
    private int penaltyBall = 3;
    private BallCountManager ballCountManager;

    // Start is called before the first frame update
    void Start()
    {
        ballCountManager = FindObjectOfType<BallCountManager>();
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
            // Give player rewards based on color
            if (obstacleColor == ColorManager.PrimaryColorsMap["Red"])
            {
                ballCountManager.ModifyBallCount("red", rewardBall);
            }
            else if (obstacleColor == ColorManager.PrimaryColorsMap["Yellow"])
            {
                ballCountManager.ModifyBallCount("yellow", rewardBall);
            }
            else if (obstacleColor == ColorManager.PrimaryColorsMap["Blue"])
            {
                ballCountManager.ModifyBallCount("blue", rewardBall);
            }

            Destroy(gameObject);
        }
        else
        {
            // Give player penalty based on color
            if (ballColor == ColorManager.PrimaryColorsMap["Red"])
            {
                ballCountManager.ModifyBallCount("red", -1 * penaltyBall);
            }
            else if (obstacleColor == ColorManager.PrimaryColorsMap["Yellow"])
            {
                ballCountManager.ModifyBallCount("yellow", -1 * penaltyBall);
            }
            else if (obstacleColor == ColorManager.PrimaryColorsMap["Blue"])
            {
                ballCountManager.ModifyBallCount("blue", -1 * penaltyBall);
            }

            Destroy(gameObject);
        }
    }

    void HandleBlendedColorCollision(Color obstacleColor, Color ballColor)
    {
        // TODO: change color based on what current obstacleColor and ballColor is
        Destroy(gameObject);
    }
}
