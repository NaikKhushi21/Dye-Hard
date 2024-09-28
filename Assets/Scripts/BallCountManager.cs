using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallCountManager : MonoBehaviour
{
    // Ball count for different colors
    public int redBallCount = 10;
    public int blueBallCount = 10;
    public int yellowBallCount = 10;

    // TextMeshProUGUI elements to show the counts
    public TextMeshProUGUI redBallText;
    public TextMeshProUGUI blueBallText;
    public TextMeshProUGUI yellowBallText;

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
        redBallText.text = "R: " + redBallCount.ToString();
        blueBallText.text = "B: " + blueBallCount.ToString();
        yellowBallText.text = "Y: " + yellowBallCount.ToString();
    }

    // Call this method when a ball is collected or used to modify the ball count
    public void ModifyBallCount(string color, int count)
    {
        switch (color)
        {
            case "red":
                redBallCount += count;
                break;
            case "blue":
                blueBallCount += count;
                break;
            case "yellow":
                yellowBallCount += count;
                break;
        }

        // Update the UI whenever the count changes
        UpdateBallCountUI();
    }
}
