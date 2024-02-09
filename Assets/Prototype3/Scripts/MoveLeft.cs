using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [HideInInspector]
    public float speed = 10.0f;
    private float leftBounds = -15.0f;
    private PlayerController3 playerControllerScript; 
    private AnimatorState runStaticState;
    
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController3>();
        
        AnimatorController playerAnimator = (AnimatorController)playerControllerScript.GetComponent<Animator>().runtimeAnimatorController; 
        AnimatorStateMachine animatorStateMachine = null;
        foreach (AnimatorControllerLayer layer in playerAnimator.layers)
        {
            if(layer.stateMachine.name == "Movement"){
                animatorStateMachine = layer.stateMachine;
                break;
            }
        }
        foreach (ChildAnimatorState state in animatorStateMachine.states)
        {
            if(state.state.name == "Run_Static"){
                runStaticState = state.state;
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(playerControllerScript.gameOver == false){
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if(transform.position.x < leftBounds && gameObject.CompareTag("Obstacle")){
            Destroy(gameObject);
        }
        if(Input.GetKeyDown(KeyCode.KeypadEnter)){
            runStaticState.speed *=2;
            speed*=2;
        }
        if(Input.GetKeyUp(KeyCode.KeypadEnter)){
            runStaticState.speed /=2;
            speed/=2;
        }
       
    }
}
