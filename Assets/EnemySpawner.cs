using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemySpawner : MonoBehaviour
{
    public string LevelName;
    public int Enemies;
    public int EnemiesSpawned;
    public bool Loop;
    public bool IsSpawning;
    public GameObject EnemyPrefab;
    private void Awake() 
    {
        LevelName = SceneManager.GetActiveScene().name;
    }

    // Start is called before the first frame update
   private void Start()
    {
        Loop = true;
        EnemiesSpawned = 0;
        StartCoroutine(SpawnEnemies());
    }

    private void FixedUpdate()
    {
        if(!IsSpawning)
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        if(!IsSpawning)
        {
            IsSpawning = true;
        for(int i = 0; i < Enemies; i++){
            Instantiate(EnemyPrefab);
            EnemiesSpawned++;
            // Debug.Log("Spawning Enemy");
            yield return new WaitForSeconds(1);
            // Debug.Log("Waited 1 second");
        }
            IsSpawning = false;
        }
        
    }
}
