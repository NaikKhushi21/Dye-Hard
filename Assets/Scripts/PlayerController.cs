using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ballPrefab;
    public float ballSpeed = 10f;   // Speed of the ball
    public Transform firePoint;     // Where the ball will be instantiated (position of the shooting point)

    private Color dynamicColor;
    private BallCountManager ballCountManager;

    // Start is called before the first frame update
    void Start()
    {
        dynamicColor = ColorManager.PrimaryColorsMap["Red"];
        ballCountManager = FindObjectOfType<BallCountManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerDirection();

        HandleMousePress();

        HandleBallColorSwitch();
    }

    void UpdatePlayerDirection()
    {
        // Step 1: Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Step 2: Calculate the direction from the object to   s the mouse
        Vector3 direction = mousePosition - transform.position;

        // Step 3: Convert the direction to an angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

        // Step 4: Rotate the object to face the mouse
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void HandleMousePress()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBall();
        }
    }

    void ShootBall()
    {
        // Instantiate the ball at the fire point's position and rotation
        GameObject ball = Instantiate(ballPrefab, firePoint.position, firePoint.rotation);
        ball.GetComponent<Renderer>().material.color = dynamicColor;

        // Get the Rigidbody2D component of the ball
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

        // Calculate the direction the object is pointing (its up vector in 2D)
        Vector2 shootDirection = firePoint.up;

        // Apply velocity to the ball in the direction the object is pointing, with a constant speed
        rb.velocity = shootDirection * ballSpeed;

        // Decrease ball count based on color
        if (dynamicColor == ColorManager.PrimaryColorsMap["Red"])
        {
            ballCountManager.ModifyBallCount("red", -1); // Decrease red ball count
        }
        else if (dynamicColor == ColorManager.PrimaryColorsMap["Yellow"])
        {
            ballCountManager.ModifyBallCount("yellow", -1); // Decrease yellow ball count
        }
        else if (dynamicColor == ColorManager.PrimaryColorsMap["Blue"])
        {
            ballCountManager.ModifyBallCount("blue", -1); // Decrease blue ball count
        }
    }

    void HandleBallColorSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) // press 1
        {
            dynamicColor = ColorManager.PrimaryColorsMap["Red"];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // press 2
        {
            dynamicColor = ColorManager.PrimaryColorsMap["Yellow"];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // press 3
        {
            dynamicColor = ColorManager.PrimaryColorsMap["Blue"];
        }
        ChangePlayerColor();
    }

    void ChangePlayerColor()
    {
        gameObject.GetComponent<Renderer>().material.color = dynamicColor;
    }
}
