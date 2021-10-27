using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    [Header("1= estas en la izquierda, apareces en la derecha")]
    [SerializeField] string escenaDestino;
    [SerializeField] int escenaOrigen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Meta();
            Debug.Log("pasar a " + escenaDestino);
            PlayerPrefs.SetInt("origen", escenaOrigen);
        }
    }

    private void Meta()
    {
        SceneManager.LoadScene(escenaDestino);

    }
}
