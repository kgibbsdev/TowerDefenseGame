using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public List<GameObject> TowerPrefabs;
    public GameObject Target;
    public Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 towerLocation = MainCamera.ScreenToWorldPoint(Input.mousePosition);
            towerLocation.z = 0;
            PlaceTower(towerLocation);
        }
    }

    // public void SelectTower()

    public void PlaceTower(Vector3 location)
    {
        GameObject tempGo = GameObject.Instantiate(TowerPrefabs[0]);
        TowerController tempController = tempGo.GetComponent<TowerController>();
        tempController.Target = Target;
        tempController.TowerCamera = MainCamera;
        tempGo.transform.position = location;
    }
}
