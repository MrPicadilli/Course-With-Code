using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotateDegreesPerSecond = 180.0f;
    private Vector3 direction = Vector3.zero;
    public float gravity = 10.0f;
    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer(){
        moveDirection = Vector3.zero;
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;//raw to not have a possible lag because of the smooth[-1;1]
        direction = transform.TransformDirection(direction);

        if (direction != Vector3.zero)
        {
            if (Vector3.Angle(transform.forward, direction) > 91)   //we go past 90 when we want to go backward
            {
                //negative direction when backward
                moveDirection = -transform.forward;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(-direction), rotateDegreesPerSecond * Time.deltaTime);
            }else{                                                  // 0 when forward, 45 when forward +east or west, 90 for east or west
                moveDirection = transform.forward;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), rotateDegreesPerSecond * Time.deltaTime);
            }
        }
        
        moveDirection.y -= gravity * Time.deltaTime; // simulate gravity and we can check if the player is grounded
        characterController.Move(moveDirection * speed * Time.deltaTime); 
    }
}
