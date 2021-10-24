using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lava : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Perdiste por lava");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        } 

        if (collision.gameObject.tag == "snake")
        {
            Debug.Log("la serpiente murio por lava");
            Destroy(collision.gameObject);
        }

    }
}
