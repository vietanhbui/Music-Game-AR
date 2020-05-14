using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicScript : MonoBehaviour
{

    AudioSource audioData;
    MusicControllerScript musicController;

    // Use this for initialization
    void Awake()
    {
        audioData = GetComponent<AudioSource>();
        GameObject playPauseButton = GameObject.FindWithTag("PlayPauseButton");
        if (playPauseButton != null)
        {
            musicController = playPauseButton.GetComponent<MusicControllerScript>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Disable the behaviour when it becomes invisible...
    void OnBecameInvisible()
    {
        audioData.Pause();
        enabled = false;
    }

    // ...and enable it again when it becomes visible.
    void OnBecameVisible()
    {
        if (musicController.isPlay)
        {
            audioData.Play(0);
        }
        else
        {
            audioData.Pause();
        }
        enabled = true;
    }
}
