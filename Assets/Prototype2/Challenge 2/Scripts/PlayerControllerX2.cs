using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX2 : MonoBehaviour
{
    public GameObject dogPrefab;
    private bool spawned = false;
    public float interval = 0.5f;
    private float timeLastDogSpawned;

    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup > timeLastDogSpawned + interval){
            spawned = false;
        }
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && spawned == false)
        {
            timeLastDogSpawned = Time.realtimeSinceStartup;
            spawned = true;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
