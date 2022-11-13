using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolloTower : TowerController
{
    public float MoveSpeed = 3.0f;
    private Vector2 TargetDirection = Vector2.zero;

    protected override void TowerStart()
    {

    }

    protected override void TowerUpdate()
    {
        TargetDirection = (Vector2)(Target.transform.position - Body.transform.position);
        TargetDirection.Normalize();
        Body.velocity = TargetDirection * 3.0f;
        Body.transform.rotation = Quaternion.LookRotation(Vector3.forward, (Vector3)TargetDirection);
    }
}
