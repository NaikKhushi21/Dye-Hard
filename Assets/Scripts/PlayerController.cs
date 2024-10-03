using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ballPrefab;
    public float ballSpeed = 20f;   
    public Transform firePoint;
    private Color dynamicColor;

    private BallCountManager ballCountManager;

    // added by khushi
    public LineRenderer aimLine;
    private float lineLength = 35f;


    // Start is called before the first frame update
    void Start()
    {
        dynamicColor = ColorManager.PrimaryColorsMap["Red"];
        ballCountManager = FindObjectOfType<BallCountManager>();

        // added by khushi
        // Initialize LineRenderer properties
        aimLine.startWidth = 0.05f;
        aimLine.endWidth = 0.05f;
        aimLine.startColor = dynamicColor;
        aimLine.endColor = dynamicColor;
        aimLine.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerDirection();

        HandleMousePress();

        HandleBallColorSwitch();
        // added by khushi
        UpdateAimLine();
    }

    // added by khushi
    void UpdateAimLine()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = mousePosition - firePoint.position;

        direction.Normalize();

        Vector3 lineEndPosition = firePoint.position + direction * lineLength;

        aimLine.SetPosition(0, firePoint.position);  // Start of the line
        aimLine.SetPosition(1, lineEndPosition);     // End of the line, fixed length
    }

    void UpdatePlayerDirection()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mousePosition.z = 0;

        Vector3 direction = mousePosition - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

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
        GameObject ball = Instantiate(ballPrefab, firePoint.position, firePoint.rotation);
        ball.GetComponent<Renderer>().material.color = dynamicColor;

        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

        Vector2 shootDirection = firePoint.up;

        rb.velocity = shootDirection * ballSpeed;

        ballCountManager.ModifyBallCount(-1);
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

        // added by khushi
        ChangeAimLineColor();
    }

    void ChangePlayerColor()
    {
        gameObject.GetComponent<Renderer>().material.color = dynamicColor;
    }

    // added by khushi
    void ChangeAimLineColor()
    {
        aimLine.startColor = dynamicColor;
        aimLine.endColor = dynamicColor;
    }
}
