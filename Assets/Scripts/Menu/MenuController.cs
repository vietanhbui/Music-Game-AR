using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    GameObject loading;

    public void StartGame()
    {
        // SceneManager.LoadScene("PlayMusicScene");
        // Use a coroutine to load the Scene in the background
        StartCoroutine(LoadYourAsyncScene());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void Awake()
    {
        loading = GameObject.FindWithTag("Loading");
    }

    // Start is called before the first frame update
    void Start()
    {
        loading.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("PlayMusicScene");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            loading.SetActive(true);
            yield return null;
        }
    }
}
