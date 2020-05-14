using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTitleScript : MonoBehaviour
{
    public GameObject musicObject;
    // Start is called before the first frame update
    void Start()
    {
        musicObject = GameObject.FindWithTag("Music");
        AudioSource audioSource = musicObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
