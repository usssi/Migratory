using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadScene("Scene1");    
    }

    public void Settings()
    {
        SceneManager.LoadScene("settings");
    }

    public void Back()
    {
        SceneManager.LoadScene("main menu");
    }

    public void LoadGameButton()
    {
        if (PlayerPrefs.HasKey("LevelSaved"))
        {
            string levelToLoad = PlayerPrefs.GetString("LevelSaved");
            SceneManager.LoadScene(levelToLoad);
        }
    }

    public void ExitApp()
    {
        PlayerPrefs.SetString("LevelSaved", "main menu");

        Application.Quit();
    }
}
