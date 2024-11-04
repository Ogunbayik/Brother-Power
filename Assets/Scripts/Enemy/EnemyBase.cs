using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected EnemySO enemySO;

    protected GameObject currentPlayer;

    public virtual void Initialize()
    {
        currentPlayer = GameObject.Find("BigPlayer");
    }
    public virtual void Movement()
    {
        var playerDistance = Vector3.Distance(transform.position, currentPlayer.transform.position);

        if(playerDistance <= enemySO.GetChaseDistance())
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPlayer.transform.position, enemySO.GetRunSpeed() * Time.deltaTime);
        }
    }
}
