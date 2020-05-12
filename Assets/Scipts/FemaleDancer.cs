using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FemaleDancer : MonoBehaviour
{

    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Disable the behaviour when it becomes invisible...
    void OnBecameInvisible()
    {
        audioData.Stop();
        enabled = false;
    }

    // ...and enable it again when it becomes visible.
    void OnBecameVisible()
    {
        audioData.Play(0);
        enabled = true;
    }
}
