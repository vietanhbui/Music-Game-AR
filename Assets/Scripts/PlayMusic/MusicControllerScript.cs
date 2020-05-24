using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

[RequireComponent(typeof(Button))]
public class MusicControllerScript : MonoBehaviour
{
    public bool isPlay = true;
    public Sprite playImage;
    public Sprite pauseImage;

    public GameObject drumObject;
    public GameObject guitarObject;
    public GameObject musicObject;
    public GameObject playPauseObject;

    public AudioClip allDayAndNight;
    public AudioClip feelings;
    public AudioClip kream;
    public AudioClip guysMyAge;
    public AudioClip giant;
    public AudioClip tinhSau;
    public AudioClip smooth;
    public List<AudioClip> clips;

    // Use this for initialization
    void Awake()
    {
        clips = new List<AudioClip>();
        clips.Add(allDayAndNight);
        clips.Add(feelings);
        clips.Add(kream);
        clips.Add(guysMyAge);
        clips.Add(giant);
        clips.Add(tinhSau);
        clips.Add(smooth);
        if (drumObject == null) { 
            drumObject = GameObject.FindWithTag("Drum");
        }
        if (musicObject == null) { 
            musicObject = GameObject.FindWithTag("Music");
        }
        if (playPauseObject == null) { 
            playPauseObject = GameObject.FindWithTag("PlayPauseButton");
        }
        if (guitarObject == null)
        {
            guitarObject = GameObject.FindWithTag("Guitar");
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

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void GoToMusicList()
    {
        SceneManager.LoadScene("MusicListScene");
    }

    public void OnClickPlayButton()
    {
        isPlay = !isPlay;
        this.ChangeImageSource();
        this.HandlePlayMusic();
    }

    public void OnClickNextButton()
    {
        AudioSource music = musicObject.GetComponent<AudioSource>();
        AudioClip clip = music.clip;
        int index = clips.IndexOf(clip);
        if (index == clips.Count - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        AudioClip nextClip = clips.ElementAt(index);
        music.clip = nextClip;
        isPlay = true;
        GameObject.FindWithTag("MusicTitle").GetComponent<Text>().text = nextClip.name;
        this.ChangeImageSource();
        this.HandlePlayMusic();
    }

    public void OnClickPrevButton()
    {
        AudioSource music = musicObject.GetComponent<AudioSource>();
        AudioClip clip = music.clip;
        int index = clips.IndexOf(clip);
        if (index == 0)
        {
            index = clips.Count - 1;
        }
        else
        {
            index--;
        }
        AudioClip nextClip = clips.ElementAt(index);
        music.clip = nextClip;
        isPlay = true;
        GameObject.FindWithTag("MusicTitle").GetComponent<Text>().text = nextClip.name;
        this.ChangeImageSource();
        this.HandlePlayMusic();
    }

    public void ChangeImageSource()
    {
        Image playPauseImage = playPauseObject.GetComponent<Image>();
        if (isPlay)
        {
            playPauseImage.sprite = pauseImage;
        }
        else
        {
            playPauseImage.sprite = playImage;
        }
    }

    public void HandlePlayMusic()
    {
        AudioSource drumMusic = drumObject.GetComponent<AudioSource>();
        TargetScript drumScript = drumObject.GetComponent<TargetScript>();
        AudioSource music = musicObject.GetComponent<AudioSource>();
        TargetScript musicScript = musicObject.GetComponent<TargetScript>();
        AudioSource guitarMusic = guitarObject.GetComponent<AudioSource>();
        TargetScript guitarScript = guitarObject.GetComponent<TargetScript>();
        if (isPlay && drumScript.targetFound)
        {
            drumMusic.Play(0);
        }
        else
        {
            drumMusic.Pause();
        }
        if (isPlay && musicScript.targetFound)
        {
            music.Play(0);
        }
        else
        {
            music.Pause();
        }
        if (isPlay && guitarScript.targetFound)
        {
            guitarMusic.Play(0);
        }
        else
        {
            guitarMusic.Pause();
        }
    }
}
