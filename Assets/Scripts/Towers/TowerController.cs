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

    private void Awake()
    {
        Rigidbody2D Body = this.GetComponent<Rigidbody2D>();
        TowerPlaceable = this.GetComponent<Placeable>();
        MyTower = TowerFactoryBuilder.BuildTower(TowerInfo, Body);
    }

    void Start()
    {
        MyTower.TowerStart();
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
            MyTower.Target = Target;
            MyTower.TowerUpdate();
        }
    }
}