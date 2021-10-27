using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puertaScript : MonoBehaviour
{
    [SerializeField] string escenaDestino;
    [SerializeField] int escenaOrigen;
    private bool colisionConPuerta;

    private void Start()
    {
        colisionConPuerta = false;
    }
    private void Update()
    {
        if (colisionConPuerta && Input.GetKeyDown(KeyCode.F))
        {
            Meta();
            Debug.Log("entrar a " + escenaDestino);
            PlayerPrefs.SetInt("origen", escenaOrigen);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            colisionConPuerta = true;
            Debug.Log("colision ocn puerta true");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            colisionConPuerta = false;
        }

    }

    private void Meta()
    {
        SceneManager.LoadScene(escenaDestino);

    }
}
