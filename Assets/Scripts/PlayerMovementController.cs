using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private const string HORIZONTAL_INPUT = "Horizontal";
    private const string VERTICAL_INPUT = "Vertical";

    private Rigidbody playerRb;

    [Header("Player Settings")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameObject body;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 movementDirection;

    private bool isWalk = false;
    private bool isRun = false;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL_INPUT);
        verticalInput = Input.GetAxis(VERTICAL_INPUT);

        movementDirection = new Vector3(horizontalInput, 0f, verticalInput);

        if (movementDirection != Vector3.zero)
        {
            isWalk = true;

            if (Input.GetKey(KeyCode.LeftShift))
                isRun = true;
            else
                isRun = false;
        }
        else
        {
            isWalk = false;
            isRun = false;
        }

        playerRb.velocity = movementDirection * walkSpeed;

        HandleRotation();
    }

    private void HandleRotation()
    {
        if (movementDirection != Vector3.zero)
        {
            var rotationY = Quaternion.LookRotation(movementDirection, Vector3.up);
            Debug.Log(rotationY);
            body.transform.rotation = Quaternion.RotateTowards(body.transform.rotation, rotationY, rotationSpeed * Time.deltaTime);
        }
    }

    public bool IsWalk()
    {
        return isWalk;
    }

    public bool IsRun()
    {
        return isRun;
    }
}
