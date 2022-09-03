using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject Target;
    private Vector2 TargetDirection = Vector2.zero;
    private Rigidbody2D Body;
    private Timer TowerTimer = new Timer();

    void Start()
    {
        TowerTimer.Callback = MoveTower;
        Body = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

    }

    void Update()
    {
        TowerTimer.Tick();
    }

    private void MoveTower()
    {
        TargetDirection = (Vector2)(Target?.transform.position - this.transform.position);
        TargetDirection.Normalize();
        Body.velocity = TargetDirection * 3.0f;
        this.transform.rotation = Quaternion.LookRotation(Vector3.forward, (Vector3)TargetDirection);
    }
}
