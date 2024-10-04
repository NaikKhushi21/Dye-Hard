using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObstacleTimer : MonoBehaviour
{
    private float lifeTime;
    private ObstacleManager obstacleManager;
    private BallCountManager ballCountManager;

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
            ApplyTimerPenalty();
            Destroy(gameObject);
        }
    }

    void UpdateTimerText()
    {
        TextMeshProUGUI timerText = ObstacleWrapperManager.GetObstacleText(gameObject);
        if (timerText != null)
        {
            // Format to one decimal place
            timerText.text = lifeTime.ToString("F1") + "s";
            if (lifeTime < 3 && timerText.color != Color.red)
            {
                timerText.color = Color.red;
                timerText.fontStyle = FontStyles.Bold;
                timerText.fontSize = 0.8f;
            }
        }
    }

    void ApplyTimerPenalty()
    {
        if (ballCountManager != null)
        {
            ballCountManager.ModifyBallCount(ballCountManager.timePenalty);
        }
    }
}
