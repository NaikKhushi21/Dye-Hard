/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallCountManager : MonoBehaviour
{
    // Ball count for different colors
    public int ballCount = 10;
    public int rewardBall = 3;
    public int penaltyBall = -3;

    // TextMeshProUGUI elements to show the counts
    public TextMeshProUGUI ballText;

    // Start is called before the first frame update
    void Start()
    {
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
        ballCount += count;
        UpdateBallCountUI();
    }
}
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallCountManager : MonoBehaviour
{
    // Ball count for different colors
    public int ballCount = 10;
    public int rewardBall = 3;
    public int penaltyBall = -3;

    
    // TextMeshProUGUI elements to show the counts and game over text
    public TextMeshProUGUI ballText;
    public TextMeshProUGUI gameOverText;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false); // Hide Game Over text at the start
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
        // Update the ball count
        ballCount += count;

        // Ensure ballCount doesn't go negative
        ballCount = Mathf.Max(ballCount, 0);

        UpdateBallCountUI();

        // Check if the ball count has reached 0
        if (ballCount <= 0)
        {
            EndGame();
        }
    }

    // Method to end the game and display Game Over message
    public void EndGame()
    {
        gameOverText.text = "Game Over!";
        gameOverText.gameObject.SetActive(true); // Show the Game Over message
        Time.timeScale = 0; // Optionally stop the game by freezing time
    }
}
