using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    AudioSource audioData;
    MusicControllerScript musicController;
    public bool targetFound = false;

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

    public void OnTargetFound()
    {
        targetFound = true;
        if (musicController.isPlay)
        {
            audioData.Play(0);
        }
        else
        {
            audioData.Pause();
        }
    }

    public void OnTargetLost()
    {
        targetFound = false;
        audioData.Pause();
    }
}
