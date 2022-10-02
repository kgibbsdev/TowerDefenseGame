using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public List<GameObject> TowerPrefabs;
    private GameObject SelectedPrefab;
    public EconomyManager GoldManager;
    public GameObject Target;
    public Camera MainCamera;

    private void Awake()
    {
        SelectedPrefab = TowerPrefabs[0];
    }

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
            if (GoldManager.CanAfford(1)) { PlaceTower(towerLocation); GoldManager.Spend(1); }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedPrefab = TowerPrefabs[0];
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectedPrefab = TowerPrefabs[1];
        }
    }

    // public void SelectTower()

    public void PlaceTower(Vector3 location)
    {
        GameObject tempGo = GameObject.Instantiate(SelectedPrefab);
        TowerController tempController = tempGo.GetComponent<TowerController>();
        tempController.Target = Target;
        tempController.TowerCamera = MainCamera;
        tempGo.transform.position = location;
    }
}
