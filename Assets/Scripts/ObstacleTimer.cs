using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleTimer : MonoBehaviour
{

    private float lifeTime;
    private BallCountManager ballCountManager;
    private ObstacleManager obstacleManager;
    // Start is called before the first frame update
    void Start()
    {
        obstacleManager = FindObjectOfType<ObstacleManager>();
        ballCountManager = FindObjectOfType<BallCountManager>();

        lifeTime = obstacleManager.GetLifeTime();

        UpdateTimerText();
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;

        UpdateTimerText();

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
        if (ballCountManager != null)
        {
            ballCountManager.ModifyBallCount(ballCountManager.timePenalty);
        }
    }
}
