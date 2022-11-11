using UnityEngine;

public class CannonTower : TowerController
{
    private Timer TowerTimer = new Timer();
    private Vector2 TargetDirection = Vector2.zero;
    public float FireFrequency = 3.0f;
    protected override void TowerStart()
    {
        base.TowerStart();
        TowerTimer.Frequency = FireFrequency;
        TowerTimer.Callback = CannonMove;
    }

    protected override void TowerUpdate()
    {
        base.TowerUpdate();
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