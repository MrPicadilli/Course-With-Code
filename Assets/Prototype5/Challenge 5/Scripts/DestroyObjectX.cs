using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{
    public int apparitionTime = 4;
    void Start()
    {
        Debug.Log("disappear");
        Destroy(gameObject, apparitionTime); // destroy particle after 2 seconds
    }


}
