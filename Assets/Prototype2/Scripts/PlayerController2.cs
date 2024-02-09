using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController2 : MonoBehaviour
{
    public float speed = 10.0f;
    public float horizontalInput;
    public float boundLimit = 10.0f;
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput =  Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime *  speed);
        // to keep the player in bound
        if(Mathf.Abs(transform.position.x) > boundLimit){
            transform.position = new Vector3( Mathf.Sign(transform.position.x) * boundLimit,transform.position.y,transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            // Launch a projectile from the player
            Instantiate(projectilePrefab,transform.position,projectilePrefab.transform.rotation);
        }
    }
}
