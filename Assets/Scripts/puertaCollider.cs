using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaCollider : MonoBehaviour
{

    private void OnEnable()
    {
        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("pared");

        foreach (GameObject obj in otherObjects)
        {
            Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "ground")
        {
            FindObjectOfType<AudioManager>().Play("cuboFloor");
            Debug.Log("cubo toca el piso");
        }
    }
}
