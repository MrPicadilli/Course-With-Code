using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    
    public float scaleRatio; 
    public Color cubeColor;
    private float timeLeft;
    public float transitionColorTime = 1.0f;
    private float changed = -0.002f;
    public float speed = 20.0f;
    void Start()
    {
        
        
        
    }
    
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime, speed * Time.deltaTime, speed * Time.deltaTime);
        if (timeLeft <= Time.deltaTime)
        {
            Renderer.material.color = cubeColor;
        
            // start a new transition
            cubeColor = new Color(Random.value, Random.value, Random.value);
            timeLeft = transitionColorTime;
            changed *= -1;
        }
        else
        {
            // transition in progress
            // calculate interpolated color
            Renderer.material.color = Color.Lerp(Renderer.material.color, cubeColor, Time.deltaTime / timeLeft);
            transform.localScale *= (1 + changed );
            // update the timer
            timeLeft -= Time.deltaTime;
        }
    }


 

}
