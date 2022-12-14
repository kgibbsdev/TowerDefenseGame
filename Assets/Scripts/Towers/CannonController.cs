using UnityEngine;

[System.Obsolete]
public class CannonController : Tower
{
    private Timer TowerTimer = new Timer();
    public float FireFrequency = 3.0f;

    public CannonController(Rigidbody2D rb, TowerScriptable scriptable) : base(rb, scriptable)
    {
        FireFrequency = scriptable.BaseSpeed;
    }

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
