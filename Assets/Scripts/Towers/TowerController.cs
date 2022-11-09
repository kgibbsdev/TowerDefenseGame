using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Placeable))]
public class TowerController : MonoBehaviour
{
    private Placeable TowerPlaceable;
    private Tower MyTower;
    public GameObject Target;
    public Camera TowerCamera;
    public TowerScriptable TowerInfo;

    public void PassTower(Tower tower)
    {
        MyTower = tower;
        MyTower.TowerStart();
    }

    private void Awake()
    {
        Rigidbody2D Body = this.GetComponent<Rigidbody2D>();
        TowerPlaceable = this.GetComponent<Placeable>();
    }

    void Start()
    {
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
            if (MyTower == null) return;
            MyTower.Target = Target;
            MyTower.TowerUpdate();
        }
    }
}