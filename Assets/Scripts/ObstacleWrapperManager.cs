using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public static class ObstacleWrapperManager
{
    static ObstacleWrapperManager()
    {

    }

    public static GameObject GetObstacle(GameObject ObstacleWrapper)
    {
        return ObstacleWrapper.transform.Find("Obstacle").gameObject;
    }

    public static TextMeshProUGUI GetObstacleText(GameObject obstacleWrapper)
    {
        // Find the TextMeshPro component in the ObstacleWrapper
        return obstacleWrapper.transform.Find("Canvas/TimerText").GetComponent<TextMeshProUGUI>();
    }
}
