using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public bool jugando;
    [SerializeField] GameObject menuPausa;


    void Start()
    {
        jugando = true;
        Time.timeScale = 1;

    }

    void Update()
    {
        // R para reload escena
        if (jugando == true && Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }

        // esc para pause
        if (jugando == true)
        {
            menuPausa.SetActive(false);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();

            }

        }
        else
        {
            menuPausa.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Jugar();
            }
        }


    }

    public void Jugar()
    {
        jugando = true;
        Time.timeScale = 1;
        Debug.Log("Resume");
    }

    public void Pause()
    {
        jugando = false;
        Time.timeScale = 0;
        Debug.Log("Pause");
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

}
