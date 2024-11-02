using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private const string ANIMATOR_RUN_PARAMETER = "isRunning";

    private PlayerMovementController movementController;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        movementController = GetComponent<PlayerMovementController>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        var isRunning = movementController.GetIsRunning();

        if (isRunning)
            RunAnimation(true);
        else
            RunAnimation(false);
    }

    public void RunAnimation(bool isActive)
    {
        animator.SetBool(ANIMATOR_RUN_PARAMETER, isActive);
    }
}
