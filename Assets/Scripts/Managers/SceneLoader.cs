using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public bool activateStatsScene;


    // Start is called before the first frame update
    void Start()
    {
        activateStatsScene = false;
    }

    // Update is called once per frame
    void Update()
    {
        LoadStatsScene();
    }

    void LoadStatsScene()
    {
        if (activateStatsScene == true)
        {
            SceneManager.LoadScene("Stats");
        }
    }

    public void GetSceneIndex(int SceneIndex)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame(int SceneIndex)
    {
        PlayerPrefs.DeleteAll();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneIndex);
    }
}
