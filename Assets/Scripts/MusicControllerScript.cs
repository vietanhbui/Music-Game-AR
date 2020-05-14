using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class MusicControllerScript : MonoBehaviour
{
    public bool isPlay = true;
    public Sprite playImage;
    public Sprite pauseImage;

    public GameObject drumObject;
    public GameObject musicObject;
    public GameObject playPauseObject;

    public AudioClip tinhSau;
    public AudioClip smooth;
    public List<AudioClip> clips;

    // Use this for initialization
    void Awake()
    {
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
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
        this.ChangeImageSource();
        this.HandlePlayMusic();
    }

    private void ChangeImageSource()
    {
        Button playPauseButton = playPauseObject.GetComponent<Button>();
        if (isPlay)
        {
            playPauseButton.image.overrideSprite = playImage;
        }
        else
        {
            playPauseButton.image.overrideSprite = pauseImage;
        }
    }

    private void HandlePlayMusic()
    {
        AudioSource drumMusic = drumObject.GetComponent<AudioSource>();
        Renderer drumRenderer = drumObject.GetComponent<Renderer>();
        AudioSource music = musicObject.GetComponent<AudioSource>();
        Renderer musicRenderer = musicObject.GetComponent<Renderer>();
        if (isPlay && drumRenderer.isVisible)
        {
            drumMusic.Play(0);
        }
        else
        {
            drumMusic.Pause();
        }
        if (isPlay && musicRenderer.isVisible)
        {
            music.Play(0);
        }
        else
        {
            music.Pause();
        }
    }
}
