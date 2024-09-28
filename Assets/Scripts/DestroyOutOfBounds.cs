using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float boundary = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        
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
            Destroy(gameObject);
        }
    }

    bool IsBallOutOfBounds()
    {
        return transform.position.y > boundary;
    }

    bool IsObstacleOutOfBounds()
    {
        return transform.position.y < -boundary;
    }
}
