using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager3 : MonoBehaviour
{
    public GameObject[] obstaclePrefab;
    private  Vector3 spawnPos = new Vector3(25,0,0);
    public float startDelay = 0.0f;
    public float repeatRate = 3.0f;
    private PlayerController3 playerControllerScript ; 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle",startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController3>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle(){
        int index = Random.Range(0,obstaclePrefab.Length);
        if(playerControllerScript.gameOver == false){
            Instantiate(obstaclePrefab[index],spawnPos,obstaclePrefab[index].transform.rotation);
        }
        
    }
}
