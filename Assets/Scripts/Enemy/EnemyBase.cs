using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected enum States
    {
        Patrol,
        Check,
        Chase,
        Attack
    }

    [SerializeField] protected EnemySO enemySO;
    [SerializeField] protected bool isXCoordinate;

    protected GameObject currentPlayer;
    protected States currentState;
    protected Vector3 firstPoint;
    protected Vector3 secondPoint;

    private Vector3 desiredPoint;
    private float checkTimer;
    private float maxCheckTimer;

    public virtual void Initialize()
    {
        desiredPoint = firstPoint;
        maxCheckTimer = Random.Range(1f, 4f);
        checkTimer = maxCheckTimer;
        currentState = States.Patrol;
        currentPlayer = GameObject.Find("BigPlayer");

        SetPatrolSettings();
    }

    private void SetPatrolSettings()
    {
        if(isXCoordinate)
        {
            firstPoint = transform.position + new Vector3(-enemySO.GetPatrolRange(), 0f, 0f);
            secondPoint = transform.position + new Vector3(enemySO.GetPatrolRange(), 0f, 0f);
        }
        else
        {
            firstPoint = transform.position + new Vector3(0f, 0f, -enemySO.GetPatrolRange());
            secondPoint = transform.position + new Vector3(0f, 0f, enemySO.GetPatrolRange());
        }
    }

    public virtual void HandlerUpdate()
    {
        switch(currentState)
        {
            case States.Patrol:
                Patrolling(desiredPoint);
                break;
            case States.Check:
                Checking();
                break;
            case States.Chase:
                break;
            case States.Attack:
                break;
        }
    }
    public virtual void Patrolling(Vector3 point)
    {
        desiredPoint = point;

        var distanceBetweenPoint = Vector3.Distance(transform.position, desiredPoint);

        if(distanceBetweenPoint >= 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, desiredPoint, enemySO.GetWalkSpeed() * Time.deltaTime);
        }
        else
        {
            currentState = States.Check;
        }
    }

    public virtual void Checking()
    {
        checkTimer -= Time.deltaTime;

        if(checkTimer <= 0)
        {
            if (desiredPoint == firstPoint)
            {
                desiredPoint = secondPoint;
            }
            else
            {
                desiredPoint = firstPoint;
            }
            maxCheckTimer = Random.Range(1f, 4f);
            checkTimer = maxCheckTimer;

            currentState = States.Patrol;
        }
    }
}
