using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BallCountManager : MonoBehaviour
{
    public int ballCount = 10;
    public int rewardBall = 4;
    public int penaltyBall = -3;
    public int timePenalty = -5;
    public int outOfBoundPenalty = -5;
    public TextMeshProUGUI ballText;

    private GameManager gameManager;

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

    void UpdateBallCountUI()
    {
        ballText.text = "Ball: " + ballCount.ToString();
    }

    public void ModifyBallCount(int count)
    {
        ballCount = Math.Max(0, ballCount + count);
        UpdateBallCountUI();

        if (ballCount == 0)
        {
            gameManager.HandleGameOver();
        }
    }
}
