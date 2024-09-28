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
            ballCountManager.ModifyBallCount(rewardBall);
            Destroy(gameObject);
        }
        else
        {
            // Give player penalty based on color
            ballCountManager.ModifyBallCount(penaltyBall);
            Destroy(gameObject);
        }
    }

    void HandleBlendedColorCollision(Color obstacleColor, Color ballColor)
    {
        if (IsBallColorOneOfBlended(obstacleColor, ballColor))
        {
            // TODO: change blended obstacle color to primary color
            ChangeBlendedObstacleColor(obstacleColor, ballColor);

        }
        else
        {
            // TODO: give player penalty based on wrong color collisions
            Destroy(gameObject);
        }
    }

    bool IsBallColorOneOfBlended(Color obstacleColor, Color ballColor)
    {
        Dictionary<Color, HashSet<Color>> blendedColorConstitutions = ColorManager.BlendedColorConstitutions;
        // Check if ballColor is part of the blended color's constituents
        Debug.Log(obstacleColor);
        HashSet<Color> currentConstituents = new(blendedColorConstitutions[obstacleColor]);
        Debug.Log(currentConstituents);
        return blendedColorConstitutions[obstacleColor].Contains(ballColor);
    }

    void ChangeBlendedObstacleColor(Color obstacleColor, Color ballColor)
    {
        // Retrieve the dictionaries
        Dictionary<Color, HashSet<Color>> blendedColorConstitutions = ColorManager.BlendedColorConstitutions;
        Dictionary<string, Color> blendedColorsMap = ColorManager.BlendedColorsMap;
        Dictionary<Color, Color> complementaryColorMap = ColorManager.ComplementaryColorMap;

        // Get the current constituent colors
        HashSet<Color> currentConstituents = new(blendedColorConstitutions[obstacleColor]);

        // Remove the ballColor from the constituent colors
        currentConstituents.Remove(ballColor);

        // Determine the new color based on the remaining constituents
        Color newObstacleColor = Color.red;
        if (currentConstituents.Count == 1) // obstacle color is green, orange, or purple
        {
            // If only one color is left, set obstacleColor to that color
            foreach (var color in currentConstituents)
            {
                newObstacleColor = color;
            }
        }
        else // obstacle color is brown
        {
            newObstacleColor = complementaryColorMap[ballColor];
        }

        gameObject.GetComponent<Renderer>().material.color = newObstacleColor;
    }
}
