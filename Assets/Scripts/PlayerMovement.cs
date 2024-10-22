using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 12f;
    public float sprintSpeed = 18f; // Add a sprint speed
    public float gravity = -19.62f; // More realistic gravity
    public float jumpHeight = 3f;
    public float maxSlopeAngle;
    private RaycastHit slopeHit;
    private bool exitingSlope;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    public Transform Camera;
    private Vector3 moveDirection;
    private float playerHeight;
    private float currentSpeed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerHeight = controller.height;
    }

    void Update()
    {
        GroundCheck();
        Move();
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset velocity when grounded
        }
    }

    bool OnSlope()
    {
        if(Physics.Raycast(transform.position, Vector3.down, out slopeHit, playerHeight * 0.5f + 0.3f)) {
            float angle = Vector3.Angle(Vector3.up, slopeHit.normal);
            return angle < maxSlopeAngle && angle != 0;
        }

        return false;
    }

    Vector3 GetSlopeMoveDirection() 
    {
        return Vector3.ProjectOnPlane(moveDirection, slopeHit.normal).normalized;
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = Camera.transform.right * x + Camera.transform.forward * z;

        // Check if the Shift key is pressed to sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controller.Move(move * sprintSpeed * Time.deltaTime);
            currentSpeed = sprintSpeed;
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
            currentSpeed = speed;
        }

        // Check if the player is grounded or on a slope
        bool canJump = isGrounded || OnSlope();

        if (canJump && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            exitingSlope = true;
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply final movement with gravity
        controller.Move(velocity * Time.deltaTime);

       if (OnSlope() && !exitingSlope)
        {
            // Use slope-adjusted movement with currentSpeed
        Vector3 slopeMoveDirection = GetSlopeMoveDirection();

        // Limiting speed on slope
        if (slopeMoveDirection.magnitude > currentSpeed)
        {
            slopeMoveDirection = slopeMoveDirection.normalized * currentSpeed;
        }
            // Use the slope-adjusted movement direction
            controller.Move(GetSlopeMoveDirection() * currentSpeed * Time.deltaTime);

           // Stick to slope (if not jumping)
        if (velocity.y < 0)
        {
            velocity.y = -2f; // Apply a small downward force to keep grounded on the slope
        }

        }
        else 
        {
            // Regular movement with speed limiting
        if (moveDirection.magnitude > currentSpeed)
        {
            moveDirection = moveDirection.normalized * currentSpeed;
        }

        controller.Move(moveDirection * currentSpeed * Time.deltaTime);
        }
    }
}