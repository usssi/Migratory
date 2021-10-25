    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptBoton : MonoBehaviour
{
    [SerializeField] GameObject plataforma;


    bool canBePressed;
    bool levantar;
    bool bajar;

    private void Start()
    {
        canBePressed = true;
        levantar = false;
        bajar = true;
    }
    private void FixedUpdate()
    {
        if (levantar && plataforma.transform.position.y <= -3.5f)
        {
            Debug.Log("se esta levantando");
            Levantar();

        }
        else if (bajar && plataforma.transform.position.y > -6.5f)
        {
            Debug.Log("esta bajando");
            Bajar();

        }

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canBePressed && collision.transform.tag == "parche")
        {
            FindObjectOfType<AudioManager>().Play("botonUp");

            transform.position = new Vector3(6, 1, 0);
            canBePressed = false;
            levantar = true;
            bajar = false;
        }
        else if (canBePressed && collision.transform.tag == "explosion")
        {
            FindObjectOfType<AudioManager>().Play("botonUp");

            transform.position = new Vector3(6, 1, 0);
            canBePressed = false;
            levantar = true;
            bajar = false;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<AudioManager>().Play("botonDown");

        transform.position = new Vector3(6, 1.1f, 0);
        canBePressed = true;
        levantar = false;
        bajar = true;
    }

    void Levantar()
    {
        plataforma.transform.position += new Vector3(0,.1f,0);
        //plataforma.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000*Time.deltaTime));


    }

    void Bajar()
    {
        plataforma.transform.position -= new Vector3(0, .05f, 0);

    }
}
