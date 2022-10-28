using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TowerScriptableObject", order = 1)]
public class TowerScriptable : ScriptableObject {
    public GameObject Prefab;
    public float BaseSpeed = 1.0f;
    public TowerType Type;
}
