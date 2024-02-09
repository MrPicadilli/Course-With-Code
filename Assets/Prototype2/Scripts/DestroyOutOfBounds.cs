using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    private float topBound = 35.0f;
    private float bottomBound = -30.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        { // delete food
            Destroy(gameObject);
        }
        else if (transform.position.z < bottomBound)
        { // check if an animal passed
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
