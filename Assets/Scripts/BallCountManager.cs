using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BallCountManager : MonoBehaviour
{
    // Ball count for different colors
    public int ballCount = 10;
    public int rewardBall = 3;
    public int penaltyBall = -3;

    private GameManager gameManager;

    // TextMeshProUGUI elements to show the counts
    public TextMeshProUGUI ballText;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        UpdateBallCountUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to update the UI text
    void UpdateBallCountUI()
    {
        ballText.text = "Ball: " + ballCount.ToString();
    }

    // Call this method when a ball is collected or used to modify the ball count
    public void ModifyBallCount(int count)
    {
        // Update the UI whenever the count changes
        ballCount = Math.Max(0, ballCount + count);
        UpdateBallCountUI();

        if (ballCount == 0)
        {
            gameManager.HandleGameOver();
        }

    }
}
