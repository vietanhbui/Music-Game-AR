using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PassNameMusic : MonoBehaviour
{
    public static string nameMusic;
    // Start is called before the first frame update
    void Start()
    {
        GameObject musicObject = GameObject.FindWithTag("Music");
        if (musicObject != null)
        {
            AudioSource music = musicObject.GetComponent<AudioSource>();
            GameObject playPauseObject = GameObject.FindWithTag("PlayPauseButton");
            MusicControllerScript musicController = playPauseObject.GetComponent<MusicControllerScript>();
            foreach (AudioClip clip in musicController.clips)
            {
                if (clip.name == nameMusic)
                    music.clip = clip;
            }
            musicController.isPlay = true;
            musicController.ChangeImageSource();
            musicController.HandlePlayMusic();
            if (nameMusic != null)
                GameObject.FindWithTag("MusicTitle").GetComponent<Text>().text = nameMusic;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickMusicItem()
    {
        nameMusic = GetComponent<Transform>().GetChild(0).gameObject.GetComponent<Text>().text;
        SceneManager.LoadScene("PlayMusicScene");
    }
}
