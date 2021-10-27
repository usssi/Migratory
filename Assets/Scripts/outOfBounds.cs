using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class outOfBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("out of bounds");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        if (collision.gameObject.tag == "snake")
        {
            Debug.Log("snake our of bounds");
            Destroy(collision.gameObject);
        }

    }
}
