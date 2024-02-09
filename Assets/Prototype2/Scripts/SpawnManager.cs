using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[ ] animalPrefabs;
    public float spawnRangeX = 20.0f;
    public float spawnPosZ = 30.0f;
    public float frequenceSpawn = 1.5f;
    public float startSpawn = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal",startSpawn, frequenceSpawn);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnRandomAnimal() {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX), 0 , spawnPosZ);
        int indexAnimal = Random.Range(0,animalPrefabs.Length);
        Instantiate(animalPrefabs[indexAnimal],spawnPos,animalPrefabs[indexAnimal].transform.rotation);
    }
}
