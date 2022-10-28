using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyManager : MonoBehaviour
{
  public GameObject Enemy1Prefab;
  public GameObject Enemy2Prefab;
  public WaveCollection waveCollection;
  public Transform spawnPoint;
  public int currentWave = 0;

  private readonly string WavesFilePath = "Assets\\Waves.xml";

  // Start is called before the first frame update
  private void Start()
  {
    ImportWaves();
    BeginWave(currentWave);
    //StartCoroutine(SpawnEnemies());
  }

  // Update is called once per frame
  private void Update()
  {
  }

  private void ImportWaves()
  {
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(WaveCollection));
    FileStream fileStream = new FileStream(WavesFilePath, FileMode.Open);
    try
    {
      waveCollection = (WaveCollection)xmlSerializer.Deserialize(fileStream);
    }
    catch(Exception ex)
    {
      throw ex;
		}
    Debug.Log("Waves Imported");
	}

  private void BeginWave(int waveNumber)
  {
    foreach (EnemyPack ep in waveCollection.Waves[waveNumber].EnemyPacks)
    {
      StartCoroutine(SpawnEnemies(ep));
    }
	}

  private IEnumerator SpawnEnemies(EnemyPack ep)
  {
    Debug.Log("SpawnEnemies");
    if (ep.Type == 1)
    {
      for (int i = 0; i <= ep.EnemyCount; i++)
      {
        var enemy = Instantiate(Enemy1Prefab);
        enemy.transform.position = spawnPoint.position + new Vector3(0, 1, 0);
        yield return new WaitForSeconds(2);
      }
    }
    if (ep.Type == 2)
    {
      for (int i = 0; i <= ep.EnemyCount; i++)
      {
        var enemy = Instantiate(Enemy2Prefab);
        enemy.transform.position = spawnPoint.position;
        yield return new WaitForSeconds(2);
      }
    }
  }


}
