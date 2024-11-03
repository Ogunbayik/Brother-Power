using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchManager : MonoBehaviour
{
    public static SwitchManager Instance { get; private set; }

    public enum States
    {
        ControllingPlayer,
        SwitchingCamera,
    }

    public States currentState;

    [SerializeField] private CinemachineVirtualCamera bigPlayerCamera;
    [SerializeField] private CinemachineVirtualCamera littlePlayerCamera;

    [SerializeField] private GameObject bigPlayer;
    [SerializeField] private GameObject littlePlayer;
    private GameObject currentPlayer;

    [SerializeField] private float maxDelayTimer;
    private float delayTimer;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }
    void Start()
    {
        currentPlayer = bigPlayer;
        currentState = States.ControllingPlayer;
        delayTimer = maxDelayTimer;
        ActivateBigPlayerCamera(true);
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case States.ControllingPlayer:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentPlayer.GetComponent<PlayerAnimationController>().RunAnimation(false);
                    PlayerScriptsActivate(false);
                    
                    currentState = States.SwitchingCamera;
                    SwitchCamera();
                }
                break;
            case States.SwitchingCamera:
                delayTimer -= Time.deltaTime;

                if(delayTimer <= 0)
                {
                    delayTimer = maxDelayTimer;
                    currentState = States.ControllingPlayer;
                    PlayerScriptsActivate(true);
                }
                break;
        }
    }

    private void ActivateBigPlayerCamera(bool isActive)
    {
        //If it is true, big camera is activate..
        bigPlayerCamera.gameObject.SetActive(isActive);
        littlePlayerCamera.gameObject.SetActive(!isActive);
    }

    private void SwitchCamera()
    {
        if (currentPlayer == bigPlayer)
        {
            currentPlayer = littlePlayer;
            ActivateBigPlayerCamera(false);
        }
        else if (currentPlayer == littlePlayer)
        {
            currentPlayer = bigPlayer;
            ActivateBigPlayerCamera(true);
        }
    }

    private void PlayerScriptsActivate(bool isActive)
    {
        currentPlayer.GetComponent<PlayerMovementController>().enabled = isActive;
        currentPlayer.GetComponent<PlayerAnimationController>().enabled = isActive;
    }


}
