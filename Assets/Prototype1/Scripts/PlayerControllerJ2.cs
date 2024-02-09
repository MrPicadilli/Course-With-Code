using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJ2 : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public float horizontalInput;
    public float horsePower;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical_J2");
        // get the user's Horizontal input
        horizontalInput = Input.GetAxis("Horizontal_J2");
        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.up,  rotationSpeed * Time.deltaTime * horizontalInput);
    }
}
