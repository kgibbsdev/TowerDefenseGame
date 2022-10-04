using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CannonController : Tower
{
    private Timer TowerTimer = new Timer();
    public float FireFrequency = 3.0f;

    public CannonController(Rigidbody2D rb) : base(rb) { }

    public override void TowerStart()
    {
        TowerTimer.Frequency = FireFrequency;
        TowerTimer.Callback = CannonMove;
    }

    public override void TowerUpdate()
    {
        TowerTimer.Tick();
    }

    private void CannonMove()
    {
        TargetDirection = (Vector2)(Target.transform.position - Body.transform.position);
        TargetDirection.Normalize();
        Body.velocity = TargetDirection * 3.0f;
        Body.transform.rotation = Quaternion.LookRotation(Vector3.forward, (Vector3)TargetDirection);
    }
}
