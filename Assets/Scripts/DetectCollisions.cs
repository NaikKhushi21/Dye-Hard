using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private BallCountManager ballCountManager;
    private ScoreManager scoreManager;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        ballCountManager = FindObjectOfType<BallCountManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("Ball"))
        {
            HandleBallCollision(other);
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            if (other.gameObject.CompareTag("Player"))
            {
                gameManager.HandleGameOver();
            }
            else
            {
                HandleObstacleCollision(other);
            }
        }
    }

    void HandleBallCollision(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            BallMoving ballController = GetComponent<BallMoving>();
            if (ballController != null)
            {
                ballController.ReverseXVelocity();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void HandleObstacleCollision(Collider2D other)
    {
        GameObject obstacle = ObstacleWrapperManager.GetObstacle(gameObject);
        Color obstacleColor = obstacle.gameObject.GetComponent<Renderer>().material.color;
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
            ballCountManager.ModifyBallCount(ballCountManager.rewardBall);

            // Give player score based on color
            scoreManager.ModifyScore(scoreManager.rewardScore);

            Destroy(gameObject);
        }
        else
        {
            // Give player penalty based on color
            ballCountManager.ModifyBallCount(ballCountManager.penaltyBall);
            Destroy(gameObject);
        }
    }

    void HandleBlendedColorCollision(Color obstacleColor, Color ballColor)
    {
        if (ColorManager.IsBallColorOneOfBlended(obstacleColor, ballColor))
        {
            // Change blended obstacle color to primary color
            ChangeBlendedObstacleColor(obstacleColor, ballColor);

            // Give player score based on color
            scoreManager.ModifyScore(scoreManager.rewardScore);
        }
        else
        {
            // Give player penalty based on wrong color collisions
            ballCountManager.ModifyBallCount(ballCountManager.penaltyBall);
            Destroy(gameObject);
        }
    }

    void ChangeBlendedObstacleColor(Color obstacleColor, Color ballColor)
    {
        Color newObstacleColor = ColorManager.GetNewObstacleColor(obstacleColor, ballColor);

        GameObject obstacle = ObstacleWrapperManager.GetObstacle(gameObject);
        obstacle.gameObject.GetComponent<Renderer>().material.color = newObstacleColor;
    }
}
