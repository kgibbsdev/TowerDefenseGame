using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
public class EnemyManager : MonoBehaviour
{
    public GameObject Enemy1Prefab;
    public GameObject Enemy2Prefab;
    public WaveCollection waveCollection;
    public Transform spawnPoint;
    public int currentWave = 0;
    public int enemiesSpawnedThisWave = 0;
    public int totalEnemiesInWave = 0;
    public bool waveRunning = false;
    private readonly string WavesFilePath = "Assets\\Waves.xml";

    // Start is called before the first frame update
    private void Start()
    {
        ImportWaves();
        BeginWave(currentWave);
    }

    // Update is called once per frame
    private void Update()
    {
       if(waveRunning)
       {
            if(enemiesSpawnedThisWave < totalEnemiesInWave)
            {
                return;
            }
            else
            {
                Debug.Log("Wave Complete");
                waveRunning = false;
                currentWave++;
                BeginWave(currentWave);
            }
       }
    }

    private void ImportWaves()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(WaveCollection));
        FileStream fileStream = new FileStream(WavesFilePath, FileMode.Open);
        try
        {
            waveCollection = (WaveCollection)xmlSerializer.Deserialize(fileStream);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        Debug.Log("Waves Imported");
    }

    private void BeginWave(int waveNumber)
    {
        if(currentWave >= waveCollection.Waves.Count)
        {
            Debug.Log("All waves complete");
            return;
        }

        enemiesSpawnedThisWave = 0;
        totalEnemiesInWave = 0;
        waveRunning = true;

        Debug.Log($"Starting wave {waveNumber}");
        foreach (EnemyPack ep in waveCollection.Waves[waveNumber].EnemyPacks)
        {
            totalEnemiesInWave += ep.EnemyCount;
            StartCoroutine(SpawnEnemies(ep));
        }
    }

    private IEnumerator SpawnEnemies(EnemyPack ep)
    {
        // Debug.Log("SpawnEnemies");
        if (ep.Type == 1)
        {
            for (int i = 0; i < ep.EnemyCount; i++)
            {
                var enemy = Instantiate(Enemy1Prefab);
                enemiesSpawnedThisWave++;
                enemy.transform.position = spawnPoint.position + new Vector3(0, 1, 0);
                yield return new WaitForSeconds(2);
            }
        }
        if (ep.Type == 2)
        {
            for (int i = 0; i < ep.EnemyCount; i++)
            {
                var enemy = Instantiate(Enemy2Prefab);
                enemiesSpawnedThisWave++;
                enemy.transform.position = spawnPoint.position;
                yield return new WaitForSeconds(2);
            }
        }
    }


}
