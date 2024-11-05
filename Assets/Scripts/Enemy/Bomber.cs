using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : EnemyBase
{
    void Start()
    {
        base.Initialize();

    }

    void Update()
    {
        base.HandlerUpdate();
    }
}
