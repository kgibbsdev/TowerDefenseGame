using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
[RequireComponent(typeof(Placeable))]
public class TowerController : MonoBehaviour
{
    public GameObject Target;

    private Vector2 TargetDirection = Vector2.zero;
    private Rigidbody2D Body;
    private Timer TowerTimer = new Timer();
    private Placeable TowerPlaceable;
    public Camera TowerCamera;

    private void Awake()
    {
        Body = this.GetComponent<Rigidbody2D>();
        TowerPlaceable = this.GetComponent<Placeable>();
    }

    void Start()
    {
        TowerTimer.Callback = MoveTower;
    }

    private void FixedUpdate()
    {

    }

    void Update()
    {
        if (TowerPlaceable.IsCarried)
        {
            Vector3 temp = TowerCamera.ScreenToWorldPoint(Input.mousePosition);
            temp.z = 0;
            this.transform.position = temp;
        }
        else {
            TowerTimer.Tick();
            this.transform.position = this.transform.position;
        }
    }

    private void MoveTower()
    {
        TargetDirection = (Vector2)(Target?.transform.position - this.transform.position);
        TargetDirection.Normalize();
        Body.velocity = TargetDirection * 3.0f;
        this.transform.rotation = Quaternion.LookRotation(Vector3.forward, (Vector3)TargetDirection);
    }
}
