using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemySpawner : MonoBehaviour
{
    public string LevelName;
    public int Enemies;
    public int EnemiesSpawned;
    public GameObject EnemyPrefab;
    private void Awake() 
    {
        LevelName = SceneManager.GetActiveScene().name;
    }

    // Start is called before the first frame update
   private void Start()
    {
        EnemiesSpawned = 0;
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator SpawnEnemies()
    {
        for(int i = 0; i < Enemies; i++){
            Instantiate(EnemyPrefab);
            Debug.Log("Before Yield");
            yield return new WaitForSeconds(2);
            Debug.Log("After Yield");
        }
       
    }
}
