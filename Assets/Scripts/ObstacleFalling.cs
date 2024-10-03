using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleFalling : MonoBehaviour
{
    private float fallingSpeed;

    private ObstacleManager obstacleManager;

    // Start is called before the first frame update
    void Start()
    {
        obstacleManager = FindObjectOfType<ObstacleManager>();

        fallingSpeed = obstacleManager.GetFallingSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * fallingSpeed * Time.deltaTime);
    }
}
