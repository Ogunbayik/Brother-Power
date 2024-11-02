using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    private const string HORIZONTAL_INPUT = "Horizontal";
    private const string VERTICAL_INPUT = "Vertical";

    private PlayerAnimationController animationController;

    [SerializeField] private float movementSpeed;
    [SerializeField] private Transform body;

    private float horizontalInput;
    private float verticalInput;
    private Vector3 movementDirection;

    private bool isRunning;
    private void Awake()
    {
        animationController = GetComponent<PlayerAnimationController>();
    }

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
            isRunning = true;
        else
            isRunning = false;

        if (isRunning && SwitchManager.Instance.currentState == SwitchManager.States.ControllingPlayer)
        {
            transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
            animationController.RunAnimation(true);
            HandleRotation();
        }
        else if (isRunning == false)
            animationController.RunAnimation(false);
    }

    private void HandleRotation()
    {
        if (movementDirection != Vector3.zero)
        {
            var rotationY = Quaternion.LookRotation(movementDirection, Vector3.up);

            Debug.Log(rotationY);
            body.transform.rotation = Quaternion.RotateTowards(body.transform.rotation, rotationY, 270 * Time.deltaTime);
        }
    }

    public bool GetIsRunning()
    {
        return isRunning;
    }
}
