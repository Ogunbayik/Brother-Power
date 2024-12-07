using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private PlayerMovementController moveController;

    private Animator animator;
    void Start()
    {
        moveController = GetComponentInParent<PlayerMovementController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (moveController.IsWalk())
            animator.SetBool("isWalk", true);
        else
            animator.SetBool("isWalk", false);

        if (moveController.IsRun())
        {
            animator.SetBool("isRun", true);
        }
        else
            animator.SetBool("isRun", false);
    }

    
}
