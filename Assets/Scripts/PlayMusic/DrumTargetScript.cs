using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumTargetScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTargetFound()
    {
        Debug.Log("found");
    }

    public void OnTargetLost()
    {
        Debug.Log("lost");
    }
}
