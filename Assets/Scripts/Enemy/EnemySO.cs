using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptable Object/Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] private string desiredName;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float chaseDistance;

    public string GetName()
    {
        return desiredName;
    }

    public float GetWalkSpeed()
    {
        return walkSpeed;
    }

    public float GetRunSpeed()
    {
        return runSpeed;
    }

    public float GetChaseDistance()
    {
        return chaseDistance;
    }
    
}
