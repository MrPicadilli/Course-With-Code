using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager4 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUpPrefab;
    private float spawnRange = 9.0f;
    public int enemyCount = 0;
    public int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerUpPrefab,GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        SpawnEnemyWave(waveNumber);
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0){
            waveNumber++;
            Instantiate(powerUpPrefab,GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
            SpawnEnemyWave(waveNumber);
        }
    }
    public void SpawnEnemyWave(int enemyToSpawn){
        for (int i = 0; i < enemyToSpawn; i++)
        {
            Instantiate(enemyPrefab,GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }

    }
    public Vector3 GenerateSpawnPosition(){
        float spawnX = Random.Range(0,spawnRange);
        float spawnZ = Random.Range(0,spawnRange);
        Vector3 randomPos = new Vector3(spawnX,0,spawnZ);
        return randomPos;
    }
}
