using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleTimer : MonoBehaviour
{
    private float minLifeTime = 5.0f;  // Minimum lifetime for an obstacle
    private float maxLifeTime = 12.0f; // Maximum lifetime for an obstacle
    private float lifeTime;            // Actual lifetime for this specific obstacle
    private BallCountManager ballCountManager;
    // Start is called before the first frame update
    void Start()
    {
        // Assign a random lifetime between minLifeTime and maxLifeTime
        lifeTime = Random.Range(minLifeTime, maxLifeTime);

        // Find the BallCountManager instance
        ballCountManager = FindObjectOfType<BallCountManager>();

        // Initialize the timer text display
        UpdateTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease the lifeTime timer
        lifeTime -= Time.deltaTime;

        // Update the timer text
        UpdateTimerText();

        // Check if the timer has run out
        if (lifeTime <= 0)
        {
            // Apply penalty if the obstacle was not destroyed in time
            ApplyTimerPenalty();
            Destroy(gameObject);
        }
    }

    // Method to update the timer text
    void UpdateTimerText()
    {
        TextMeshProUGUI timerText = ObstacleWrapperManager.GetObstacleText(gameObject);
        if (timerText != null)
        {
            timerText.text = lifeTime.ToString("F1") + "s"; // Format to one decimal place
            if (lifeTime < 3 && timerText.color != Color.red)
            {
                timerText.color = Color.red;
                timerText.fontStyle = FontStyles.Bold;
                timerText.fontSize = 0.8f;
            }
        }
    }

    // Method to apply the penalty when the obstacle's timer runs out
    void ApplyTimerPenalty()
    {
        // Reduce the ball count by 1 when the obstacle is not destroyed in time
        if (ballCountManager != null)
        {
            ballCountManager.ModifyBallCount(ballCountManager.timePenalty);
        }
    }
}
