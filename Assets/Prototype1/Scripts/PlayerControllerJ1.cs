using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerJ1 : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public float horizontalInput;
    public float horsePower;
    private Rigidbody playerRb;
    [SerializeField] private GameObject centerOfMass;
    public TextMeshProUGUI speedometerText;
    public TextMeshProUGUI rpmText;
    public float rpm;

    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
        
    }

    private void Update() {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");
        // get the user's Horizontal input
        horizontalInput = Input.GetAxis("Horizontal");
        if(IsOnGround()){

            // move the plane forward at a constant rate
            //transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
            // tilt the plane up/down based on up/down arrow keys
            transform.Rotate(Vector3.up,  rotationSpeed * Time.deltaTime * horizontalInput);

            // print UI
            speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f); // 3.6 for km
            speedometerText.text = "Speed : " + speed + "km";
            rpm = Mathf.Round(speed%30) * 40;
            rpmText.text = "RPM : " + rpm;
        }
        
    }
    private bool IsOnGround(){
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround >= 1)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
