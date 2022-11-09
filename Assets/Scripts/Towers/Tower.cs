using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Tower
{
    protected Rigidbody2D Body;
    public Vector2 TargetDirection;
    public int Cost = 1;
    public GameObject Target; // Perhaps make a parameter passed in tower update?

    public Tower(Rigidbody2D rb, TowerScriptable scriptable)
    {
        Body = rb;
    }

    abstract public void TowerStart();

    abstract public void TowerUpdate();
}
