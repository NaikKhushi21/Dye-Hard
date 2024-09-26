using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBoundary = 25.0f;
    private float leftBoundary = -30;
    private float rightBoundary = 30;
    private float bottomBoundary = -25.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("ball") && IsBallOutOfBounds())
        {
            Destroy(gameObject);
        }
        else if (IsFallingObject() && IsFallingObjectOutOfBounds())
        {
            Destroy(gameObject);
        }
    }

    private bool IsBallOutOfBounds()
    {
        return transform.position.z > topBoundary || transform.position.x < leftBoundary || transform.position.y > rightBoundary;
    }

    private bool IsFallingObject()
    {
        return gameObject.CompareTag("Glass") || gameObject.CompareTag("Obstacle");
    }

    private bool IsFallingObjectOutOfBounds() => transform.position.z < bottomBoundary;
}
