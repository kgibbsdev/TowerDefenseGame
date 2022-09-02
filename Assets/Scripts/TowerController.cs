using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject Target;
    private Vector2 TargetDirection = Vector2.zero;
    private Rigidbody2D Body;
    void Start()
    {
        Body = this.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(TargetDirection != Vector2.zero)
        {
            Body.velocity = TargetDirection * 5.0f;
        }
    }

    void Update()
    {
        TargetDirection = Vector2.zero;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Body.velocity = Body.velocity + Vector2.right * 5.0f;
            TargetDirection = (Vector2)(Target?.transform.position - this.transform.position);
            TargetDirection.Normalize();
        }
    }
}
