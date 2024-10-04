using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float boundary = 10.0f;
    private BallCountManager ballCountManager;

    // Start is called before the first frame update
    void Start()
    {
        ballCountManager = FindObjectOfType<BallCountManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("Ball") && IsBallOutOfBounds())
        {
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("Obstacle") && IsObstacleOutOfBounds())
        {
            ballCountManager.ModifyBallCount(ballCountManager.outOfBoundPenalty);
            Destroy(gameObject);
        }
    }

    bool IsBallOutOfBounds()
    {
        return transform.position.y > boundary || transform.position.y < -boundary;
    }

    bool IsObstacleOutOfBounds()
    {
        return transform.position.y < -boundary;
    }
}
